using System;
using System.Collections.Generic;
using System.Text;

namespace Ninegoldy.Models.Users
{
    public interface IUserRepository : IRepositoryBase<UserDTO>
    {
        bool ExistsEmail(string email);
        
        Task<UserDTO?> GetByEmailAndPasswordAsync(string email, string hashedPassword);
    }
}
