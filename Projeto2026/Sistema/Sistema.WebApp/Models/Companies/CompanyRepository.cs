using Ninegoldy.Data;
using Ninegoldy.Models.Companies;
using System.Linq.Expressions;

namespace Ninegoldy.Models.Companies
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<CompanyDTO> AddAsync(CompanyDTO entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<CompanyDTO>> FindAsync(Expression<Func<CompanyDTO, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<CompanyDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CompanyDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
