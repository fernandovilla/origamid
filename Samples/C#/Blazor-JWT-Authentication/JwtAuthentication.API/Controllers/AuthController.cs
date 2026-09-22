using JwtAuthentication.API.Entities;
using JwtAuthentication.API.Models;
using JwtAuthentication.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration, IAuthService service) 
        : ControllerBase
    {        
        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterAsync(UserDto request)
        {
            var newUser = await service.RegisterAsync(request);

            if (newUser == null)
                return BadRequest("Cannot register the user");

            return Ok(newUser);
        }

        [HttpPost("token")]
        public async Task<ActionResult<string>> LoginAsync(UserDto request)
        {
            var token = await service.LoginAsync(request);

            if (string.IsNullOrEmpty(token))
                return BadRequest("Invalid login");
                
            return Ok(token);
        }


        [Authorize(Roles = "ADMIN")]
        [HttpGet("only-admin")]
        public async Task<IActionResult> OnlyAdminEndPoint()
        {
            return Ok("You are authenticated, Admin!");
        }

        [Authorize]
        [HttpGet("any-user")]
        public async Task<IActionResult> AnyUserEndPoint()
        {
            return Ok("You are authenticated, User!");
        }
    }
}
