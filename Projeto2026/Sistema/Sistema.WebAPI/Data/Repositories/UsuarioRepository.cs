using Sistema.Domain.Models.Usuarios;

namespace Sistema.WebAPI.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<UsuarioDTO> AddAsync(UsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UsuarioDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UsuarioDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
