using Ninegoldy.Models.Users;

namespace Ninegoldy.Services.Authentication
{
    public interface IAuthService
    {
        Task<UserDTO> RegisterUserAsync(UserRequest userRequest);

        Task<UserDTO> LoginAsync(UserLogin userRequest);        
    }
}
