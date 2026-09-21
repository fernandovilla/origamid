using Azure.Core;
using JwtAuthentication.API.Data;
using JwtAuthentication.API.Entities;
using JwtAuthentication.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthentication.API.Services
{
    public class AuthService(AppDbContext context, IConfiguration configuration) 
        : IAuthService
    {        
        public async Task<string?> LoginAsync(UserDto request)
        {
            var user = context.Users.FirstOrDefault(i => i.Username == request.Username);

            if (user is null)
                return null;

            var passwordOk = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Success;

            if (!passwordOk)
                return null;

            return CreateToken(user);
        }

        public async Task<User?> RegisterAsync(UserDto request)
        {
            if (await context.Users.AnyAsync(i => i.Username == request.Username))
                return null;

            User user = new();
            user.Username = request.Username;
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, request.Password);

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "ADMIN")
            };

            var keyToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("CredentialSettings:Token")!));
            var creds = new SigningCredentials(keyToken, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                    issuer: configuration.GetValue<string>("CredentialSettings:Issuer"),
                    audience: configuration.GetValue<string>("CredentialSettings:Audience"),
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(3),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
