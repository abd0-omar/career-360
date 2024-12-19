using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication1.DTOs.Customer;
using WebApplication1.DTOs.Order;
using WebApplication1.DTOs.OrderDetails;
using WebApplication1.UnitOfWorks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(UserManager<IdentityUser> userManager, UnitOfWork unitOfWork)
        : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new customer")]
        [SwaggerResponse(200, "Customer created successfully")]
        [SwaggerResponse(400, "Invalid input")]
        public IActionResult Create(AddCustomerDto customerDto)
        {
            Customer customer = new Customer()
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
                PhoneNumber = customerDto.PhoneNumber,
                Email = customerDto.Email,
                UserName = customerDto.UserName
            };

            IdentityResult result = userManager.CreateAsync(customer, customerDto.Password).Result;

            if (result.Succeeded)
            {
                IdentityResult roleResult = userManager.AddToRoleAsync(customer, "customer").Result;
                if (roleResult.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(roleResult.Errors);
                }
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all customers")]
        [SwaggerResponse(200, "Customers retrieved successfully")]
        public IActionResult GetAll()
        {
            var customers = userManager.GetUsersInRoleAsync("customer").Result;
            if(customers.Count == 0) return NotFound();
            List<ViewCustomerDto> customerDtOs = new List<ViewCustomerDto>();

            foreach (Customer customer in customers)
            {
                ViewCustomerDto customerDto = new ViewCustomerDto()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Address = customer.Address,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email,
                    UserName = customer.UserName
                };

                customerDtOs.Add(customerDto);
            }

            return Ok(customerDtOs);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a customer by ID")]
        [SwaggerResponse(200, "Customer retrieved successfully")]
        [SwaggerResponse(404, "Customer not found")]
        public IActionResult GetById(string id)
        {
            var customer = (Customer)userManager.FindByIdAsync(id).Result;

            if (customer != null)
            {
                ViewCustomerDto customerDTO = new ViewCustomerDto()
                {
                    Name = customer.Name,
                    Address = customer.Address,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email,
                    UserName = customer.UserName
                };

                return Ok(customerDTO);

            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
        [HttpPut("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Edit an existing customer")]
        [SwaggerResponse(200, "Customer updated successfully")]
        [SwaggerResponse(404, "Customer not found")]
        public IActionResult Edit(EditCustomerDto customerDto)
        {
            var customer = (Customer)userManager.FindByIdAsync(customerDto.Id).Result;

            if (customer != null)
            {
                customer.Name = customerDto.Name;
                customer.Address = customerDto.Address;
                customer.PhoneNumber = customerDto.PhoneNumber;
                customer.Email = customerDto.Email;
                customer.UserName = customerDto.UserName;

                IdentityResult result = userManager.UpdateAsync(customer).Result;

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a customer")]
        [SwaggerResponse(200, "Customer deleted successfully")]
        [SwaggerResponse(404, "Customer not found")]
        public ActionResult Delete(string id)
        {
            var customer = userManager.FindByIdAsync(id).Result;
            if (customer == null)
            {
                return NotFound();
            }

            var result = userManager.DeleteAsync(customer).Result;
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
        [HttpGet("{id}/orders")]
        [SwaggerOperation(Summary = "Get all orders for a customer")]
        [SwaggerResponse(200, "Orders retrieved successfully")]
        [SwaggerResponse(404, "Customer not found")]
        public IActionResult GetOrders(string id)
        {
            var customer = (Customer)userManager.FindByIdAsync(id).Result;

            if (customer != null)
            {
                var orders = unitOfWork.OrderRepo.GetAll().Where(o => o.CustomerId == id).ToList();
                var viewOrdersDto = new List<ViewOrderDto>();

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
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        OrderDate = order.OrderDate,
                        TotalPrice = order.TotalPrice,
                        Status = order.Status,
                        ViewOrderDetailsList = viewOrderDetailsListDto
                    };
                    viewOrdersDto.Add(viewOrderDto);
                }

                return Ok(viewOrdersDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
