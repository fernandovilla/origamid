using Gestao.App.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.App.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository repository;
        private readonly IConfigurationManager configuration;

        private int PageSize => configuration.GetValue<int>("Pagination:PageSize");

        public AccountController(IAccountRepository repository, IConfigurationManager configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] int companyId, [FromQuery] int pageIndex, [FromQuery] string searchWord)
        {
            var data = await repository.GetAllAsync(companyId, pageIndex, PageSize, searchWord);

            return Ok(data);
        }
    }
}
