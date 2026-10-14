using Gestao.Domain.Model.Companies;

namespace Gestao.App.Services.Companies
{
    public interface ICompanyService
    {
        Task<Company> CreateAsync();
        Task<Company> CreateAsync(Company company);
    }
}
