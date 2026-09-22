using JwtAuthentication.Lib.Entities;
using JwtAuthentication.Lib.Models;
using Refit;

namespace JwtAuthentication.Web.Services
{
    public interface IAuthenticationService
    {     
        [Post("/api/token")]
        public Task<User> LoginAsync([Body] UserDto request);

        [Post("/api/token/refresh")]
        public Task<TokenResponseDto> RefreshTokenAsync([Body] RefreshTokenRequestDto request);
    }
}
