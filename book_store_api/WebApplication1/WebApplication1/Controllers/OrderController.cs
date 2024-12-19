using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.UnitOfWorks;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication1.DTOs.Order;
using WebApplication1.DTOs.OrderDetails;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
// I prefer not to use a mapper
// I know it's verbose,
// but it makes feel more comfortable when doing mapping every variable by hand
public class OrderController(UnitOfWork unitOfWork) : ControllerBase
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpGet]
    [SwaggerOperation(Summary = "Get all orders")]
    [SwaggerResponse(200, "Orders retrieved successfully")]
    [SwaggerResponse(404, "No orders found")]
public ActionResult<List<ViewOrderDto>> GetAll()
{
    List<Order> orders = unitOfWork.OrderRepo.GetAll();
    var ordersDto = new List<ViewOrderDto>();

    foreach (var order in orders)
    {
        var viewOrderDetailsListDto = new List<ViewOrderDetailsDto>();
        foreach (var orderDetails in order.OrderDetailsList)
        {
            var viewOrderDetailsDto = new ViewOrderDetailsDto()
            {
                OrderId = orderDetails.OrderId,
                BookId = orderDetails.BookId,
                Quantity = orderDetails.Quantity,
                UnitPrice = orderDetails.UnitPrice,
            };
            viewOrderDetailsListDto.Add(viewOrderDetailsDto);
        }

        var viewOrderDto = new ViewOrderDto()
        {
            Id = order.Id, // Map the ID here
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
            Status = order.Status,
            ViewOrderDetailsList = viewOrderDetailsListDto
        };
        ordersDto.Add(viewOrderDto);
    }

    if (ordersDto.Count == 0) return NotFound();
    return Ok(ordersDto);
}

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get an order by ID")]
    [SwaggerResponse(200, "Order retrieved successfully")]
    [SwaggerResponse(404, "Order not found")]
    public ActionResult GetById(int id)
    {
        var order = unitOfWork.OrderRepo.GetById(id);
        if (order == null) return NotFound();

        var viewOrderDetailsListDto = new List<ViewOrderDetailsDto>();
        foreach (var orderDetails in order.OrderDetailsList)
        {
            var viewOrderDetailsDto = new ViewOrderDetailsDto()
            {
                OrderId = orderDetails.OrderId,
                BookId = orderDetails.BookId,
                Quantity = orderDetails.Quantity,
                UnitPrice = orderDetails.UnitPrice,
            };
            viewOrderDetailsListDto.Add(viewOrderDetailsDto);
        }

        var viewOrderDto = new ViewOrderDto()
        {
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
            Status = order.Status,
            ViewOrderDetailsList = viewOrderDetailsListDto
        };

        return Ok(viewOrderDto);
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer")]
    [HttpPost]
    [SwaggerOperation(Summary = "Add a new order")]
    [SwaggerResponse(200, "Order added successfully")]
    [SwaggerResponse(400, "Invalid input")]
    public ActionResult Add(AddOrderDto addOrderDto)
    {
        Order basicOrderInfo = new Order()
        {
            CustomerId = addOrderDto.CustomerId,
            OrderDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
            Status = Status.Pending
        };
        unitOfWork.OrderRepo.Insert(basicOrderInfo);
        unitOfWork.Save();

        decimal totalPrice = 0;
        foreach (var item in addOrderDto.Books)
        {
            Book? b = unitOfWork.BookRepo.GetById(item.BookId);
            if (b == null) continue;
            totalPrice += (b.Price * item.Quantity);
            OrderDetails details = new OrderDetails()
            {
                OrderId = basicOrderInfo.Id,
                BookId = item.BookId,
                Quantity = item.Quantity,
                UnitPrice = b.Price,
            };
            if (b.Stock > details.Quantity)
            {
                basicOrderInfo.OrderDetailsList.Add(details);

                b.Stock -= item.Quantity;
                unitOfWork.BookRepo.Update(b);
            }
            else
            {
                return BadRequest("Invalid quantity");
            }
        }

        basicOrderInfo.TotalPrice = totalPrice;

        unitOfWork.OrderRepo.Update(basicOrderInfo);
        unitOfWork.Save();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update the status of an existing order")]
    [SwaggerResponse(200, "Order status updated successfully")]
    [SwaggerResponse(404, "Order not found")]
    public ActionResult UpdateOrderStatus(int id, EditOrderStatusDto editOrderDto)
    {
        var order = unitOfWork.OrderRepo.GetById(id);
        if (order == null) return NotFound();

        order.Status = editOrderDto.Status;
        unitOfWork.OrderRepo.Update(order);
        unitOfWork.Save();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete an order")]
    [SwaggerResponse(200, "Order deleted successfully")]
    [SwaggerResponse(404, "Order not found")]
    public ActionResult Delete(int id)
    {
        var order = unitOfWork.OrderRepo.GetById(id);
        if (order == null) return NotFound();

        unitOfWork.OrderRepo.Delete(order.Id);
        unitOfWork.Save();

        return Ok();
    }
}
