using JwtAuthentication.API.Services;
using JwtAuthentication.Lib.Entities;
using JwtAuthentication.Lib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> TokenAsync(UserDto request)
        {
            var responseToken = await service.LoginAsync(request);

            if (responseToken == null)
                return BadRequest("Invalid login");
                
            return Ok(responseToken);
        }

        [HttpPost("token/refresh")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            var responseToken = await service.RefreshTokensAsync(request);

            if (responseToken == null || responseToken?.AccessToken == null || responseToken?.RefreshToken == null)
                return Unauthorized("Invalid refresh token");

            return Ok(responseToken);
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
