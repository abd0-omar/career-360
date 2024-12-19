using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication1.DTOs.Account;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Logs in a user.", Description = "Logs in a user and returns a JWT token if successful.")]
        public IActionResult LogIn(LoginDto logInDTO)
        {
            var result = signInManager.PasswordSignInAsync(logInDTO.Username, logInDTO.Password, false, false).Result;

            if (result.Succeeded)
            {
                var user = userManager.FindByNameAsync(logInDTO.Username).Result;

                var userdata = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                var roles = userManager.GetRolesAsync(user).Result;

                foreach (var role in roles)
                {
                    userdata.Add(new Claim(ClaimTypes.Role, role));
                }

                string key = "welcome to my very secret key very secret key very secret";
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: userdata,
                    expires: DateTime.Now.AddDays(2),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenString);
            }
            else
            {
                return Unauthorized("Invalid UserName or Password");
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
        [HttpPut("ChangePassword")]
        [Authorize]
        [SwaggerOperation(Summary = "Changes the password of the logged-in user.", Description = "Changes the password of the logged-in user.")]
        public IActionResult ChangePassword(ChangePasswordDto passwordDto)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByIdAsync(User.Identity.Name).Result;

                if (user != null)
                {
                    var result = userManager.ChangePasswordAsync(user, passwordDto.Oldpassword, passwordDto.Newpassword).Result;

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
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
        [HttpPost("logout")]
        [Authorize]
        [SwaggerOperation(Summary = "Logs out the current user.", Description = "Logs out the current user.")]
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return Ok();
        }
    }
}