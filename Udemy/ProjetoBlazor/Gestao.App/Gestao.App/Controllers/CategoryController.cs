using Gestao.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.App.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository repository;
        private readonly IConfigurationManager configuration;

        private int PageSize => configuration.GetValue<int>("Pagination:PageSize");

        public CategoryController(ICategoryRepository repository, IConfigurationManager configuration)
        {
            this.repository = repository;                
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int companyId, [FromQuery] int pageIndex)
        {            
            var data = await repository.GetAllAsync(null, companyId, pageIndex, PageSize); 

            return Ok(data);
        }
    }
}
