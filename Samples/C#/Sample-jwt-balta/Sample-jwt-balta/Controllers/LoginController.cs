using Microsoft.AspNetCore.Mvc;
using Sample_jwt_balta.Models;
using Sample_jwt_balta.Repositories;
using Sample_jwt_balta.Services;

namespace Sample_jwt_balta.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("token")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserDto userDto)
        {
            var user = (new UserRepository()).Get(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is invalid" });

            var secretKey = _config.GetValue<string>("Secret:SecretKey");
            var token = (new TokenService(secretKey)).GenerateToken(user);

            return Ok(new
            {
                token = token,
                user = user
            });
        }

        [HttpPost]
        [Route("validate")]
        public async Task<ActionResult<dynamic>> ValidateToken([FromBody] string token)
        {
            var secretKey = _config.GetValue<string>("Secret:SecretKey");
            var validated = (new TokenService(secretKey)).ValidateToken(token);

            return Ok(new
            {
                token = token,
                isValid = validated
            });
        }
    }
}
