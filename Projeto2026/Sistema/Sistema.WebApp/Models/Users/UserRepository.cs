using Ninegoldy.Data;
using Ninegoldy.Models.Users;
using System.Data.SqlTypes;

namespace Ninegoldy.Models.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<UserDTO> AddAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
