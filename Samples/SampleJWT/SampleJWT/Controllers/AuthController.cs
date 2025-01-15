using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SampleJWT.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public static List<User> users = new List<User>();

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration config)
        {
            _configuration = config;

            Register(new UserDto { Username = "admin", Password = "admin" });
        }

        [HttpPost("")]
        public ActionResult<User> Login(UserDto userRequest)
        {
            if (users.Count > 0 && !users.Where(i => i.UserName.Equals(userRequest.Username)).Any())
            {
                return BadRequest("User not found");
            }

            var user = users.Where(i => i.UserName.Equals(userRequest.Username)).FirstOrDefault();

            if (!BCrypt.Net.BCrypt.Verify(userRequest.Password, user?.PasswordHash))
                return BadRequest("Wrong login or password");

            string token = CreateToken(user);

            return Ok(new
            {
                bearer = token.ToString()
            }
            );
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto userRequest)
        {
            if (users.Count > 0 && users.FirstOrDefault(i => i.UserName.Equals(userRequest.Username)) != null)
            {
                return BadRequest("Usuário já registrado");
            }

            var user = new User();
            user.UserName = userRequest.Username;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);

            users.Add(user);

            return Ok(user);
        }

        [HttpGet("validateToken")]
        public ActionResult<string> ValidToke(string token)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            var tokenValue = tokenHandle.ReadToken(token);

            if (tokenValue != null)
                return Ok("Token is valid");

            return NotFound("Token is invalid or expired");
        }


        private string CreateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var claims = new ClaimsIdentity([
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "admin")
                ]);

            var tokenHandle = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = tokenHandle.CreateToken(tokenDescriptor);
            var jwt = tokenHandle.WriteToken(token);

            return jwt;
        }
    }
}
