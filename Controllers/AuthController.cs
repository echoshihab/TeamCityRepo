using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestRunnerDemo.Models;

namespace TestRunnerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            if (loginDto is not { Name: "test", Password: "test" })
            {
                return this.Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginDto.Name),
                new Claim(ClaimTypes.Role, "Administrator")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
            };

            await this.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return this.Ok();

        }

    }
}

