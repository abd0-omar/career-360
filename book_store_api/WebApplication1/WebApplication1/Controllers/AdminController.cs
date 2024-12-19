using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication1.DTOs;
using WebApplication1.DTOs.Admin;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController(UserManager<IdentityUser> userManager)
        : ControllerBase
    {
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        [SwaggerOperation(Summary = "Creates and Admin")]
        [HttpPost]
        public IActionResult Create(AddAdminDto adminDto)
        {
            IdentityUser admin = new IdentityUser()
            {
                UserName = adminDto.UserName,
                Email = adminDto.Email,
                PhoneNumber = adminDto.Phone
            };

            IdentityResult result = userManager.CreateAsync(admin, adminDto.Password).Result;

            if (result.Succeeded)
            {
                IdentityResult roleResult = userManager.AddToRoleAsync(admin, "admin").Result;
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

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        [SwaggerOperation(Summary = "Get all admins")]
        [SwaggerResponse(200, "Admins retrieved successfully")]
        [SwaggerResponse(404, "No admins found")]
        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var admins = userManager.GetUsersInRoleAsync("admin").Result;

            if (admins.Count == 0)
            {
                return NotFound();
            }

            var adminsDtos = new List<ViewAdminDto>();

            foreach (var admin in admins)
            {
                adminsDtos.Add(new ViewAdminDto()
                {
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Phone = admin.PhoneNumber
                });
            }

            return Ok(adminsDtos);
        }
    }
}
