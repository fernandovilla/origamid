using Gestao.App.Data;
using Gestao.Domain.Model.Companies;
using Microsoft.AspNetCore.Identity;

namespace Gestao.App.Services.Companies
{
    public class CompanyService(IUnitOfWorkFactory unitOfWorkFactory) : ICompanyService
    {
        public async Task<Company> CreateAsync(Company company)
        {
            using var unit = unitOfWorkFactory.Create();

            await unit.CompanyRepository.CreateAsync(company);

            await unit.SaveChangesAsync();

            return company;
        }

        public async Task<Company> CreateAsync()
        {
            return await CreateAsync(new Company());
        }
    }
}
