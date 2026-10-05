using Ninegoldy.Data;
using Ninegoldy.Models.Companies;

namespace Ninegoldy.Models.Companies
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<CompanyDTO> AddAsync(CompanyDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CompanyDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CompanyDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
