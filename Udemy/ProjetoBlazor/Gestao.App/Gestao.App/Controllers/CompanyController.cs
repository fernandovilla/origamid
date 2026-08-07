using Gestao.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.App.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository repository;
        private readonly IConfigurationManager configuration;

        private int PageSize => configuration.GetValue<int>("Pagination:PageSize");

        public CompanyController(ICompanyRepository repository, IConfigurationManager configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] Guid applicationUserId, int pageIndex, string searchWord)
        {
            var data = await repository.GetAllAsync(applicationUserId, pageIndex, PageSize, searchWord);

            return Ok(data);
        }
    }
}
