using JwtAuthentication.API.Data;
using JwtAuthentication.Lib.Entities;
using JwtAuthentication.Lib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JwtAuthentication.API.Services
{
    public class AuthService(AppDbContext context, IConfiguration configuration)
        : IAuthService
    {
        private (string, DateTime) CreateToken(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var keyToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("CredentialSettings:Token")!));
            var creds = new SigningCredentials(keyToken, SecurityAlgorithms.HmacSha512);

            var expiresDateTime = DateTime.UtcNow.AddMinutes(3);

            var tokenDescriptor = new JwtSecurityToken(
                    issuer: configuration.GetValue<string>("CredentialSettings:Issuer"),
                    audience: configuration.GetValue<string>("CredentialSettings:Audience"),
                    claims: claims,
                    expires: expiresDateTime,
                    signingCredentials: creds
                );

            return (new JwtSecurityTokenHandler().WriteToken(tokenDescriptor), expiresDateTime);
        }
        
        private string CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
        
        private async Task<string> GenerateAndSaveRefreshToken(User user)
        {
            user.RefreshToken = CreateRefreshToken();
            user.RefreshTokenExpityTime = DateTime.UtcNow.AddDays(7);

            await context.SaveChangesAsync();

            return user.RefreshToken;
        }
        
        private async Task<User?> ValidateRefreshTokenAsync(int userId, string refreshToken)
        {
            var user = await context.Users.FindAsync(userId);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpityTime <= DateTime.UtcNow)
                return null;

            return user;
        }

        private async Task<TokenResponseDto> CreateTokenResponseAsync(User user)
        {
            (string accessToken, DateTime expiresToken) = CreateToken(user);
            var refreshToken = await GenerateAndSaveRefreshToken(user);

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                AccessTokenExpiresAt = expiresToken,
                RefreshToken = refreshToken,                
            };
        }

        public async Task<TokenResponseDto?> LoginAsync(UserDto request)
        {
            var user = context.Users.FirstOrDefault(i => i.Username == request.Username);

            if (user is null)
                return null;

            var passwordOk = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Success;

            if (!passwordOk)
                return null;

            return await CreateTokenResponseAsync(user);
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

        public async Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request)
        {
            var user = await ValidateRefreshTokenAsync(request.UserId, request.RefreshToken);

            if (user == null)
                return null;

            return await CreateTokenResponseAsync(user);
        }


        

        
    }
}
