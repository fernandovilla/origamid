using Gestao.App.Data.Repositories;
using Gestao.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.App.Controllers
{
    [ApiController]
    [Route("api/financialtransactions")]
    public class FinancialTransactionController : Controller
    {
        private readonly IFinancialTransactionRepository repository;
        private readonly IConfigurationManager configuration;

        private int PageSize => configuration.GetValue<int>("Pagination:PageSize");

        public FinancialTransactionController(IFinancialTransactionRepository repository, IConfigurationManager configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] FinancialTransactionTypeEnum type, [FromQuery] int companyId, [FromQuery] int pageIndex, [FromQuery] string searchWord)
        {
            var data = await repository.GetAllAsync(companyId, type, pageIndex, PageSize, searchWord);

            return Ok(data);
        }
    }
}
