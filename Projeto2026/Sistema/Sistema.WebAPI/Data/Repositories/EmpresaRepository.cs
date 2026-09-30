using Sistema.Domain.Models.Empresas;

namespace Sistema.WebAPI.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationDbContext _context;
        public EmpresaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<EmpresaDTO> AddAsync(EmpresaDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<EmpresaDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(EmpresaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
