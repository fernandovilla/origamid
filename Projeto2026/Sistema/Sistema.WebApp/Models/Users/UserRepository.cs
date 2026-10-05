using Microsoft.EntityFrameworkCore;
using Ninegoldy.Data;
using Ninegoldy.Models.Users;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace Ninegoldy.Models.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<UserDTO> _users => _context.Users;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ExistsEmail(string email)
        {
            return _users.FirstOrDefault(i => i.Email.ToUpper() == email.ToUpper().Trim()) != null;
        }

        public Task<UserDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<UserDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<UserDTO>> FindAsync(Expression<Func<UserDTO, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> AddAsync(UserDTO entity, CancellationToken cancellationToken = default)
        {
            var result = await _users.AddAsync(entity, cancellationToken); 
            return result.Entity;
        }

        public Task UpdateAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO?> GetByEmailAndPasswordAsync(string email, string hashedPassword)
        {
            return _users.FirstOrDefault(i => i.Email.ToUpper() == email.ToUpper().Trim());
        }
    }
}
