using JwtAuthentication.Lib.Entities;
using JwtAuthentication.Lib.Models;
using Refit;

namespace JwtAuthentication.Web.Client.Services
{
    public interface IAuthenticationService
    {     
        [Post("/api/auth/token")]
        public Task<User> LoginAsync([Body] UserDto request);

        [Post("/api/auth/token/refresh")]
        public Task<TokenResponseDto> RefreshTokenAsync([Body] RefreshTokenRequestDto request);
    }
}
