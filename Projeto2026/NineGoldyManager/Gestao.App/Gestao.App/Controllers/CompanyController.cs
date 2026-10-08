using FluentValidation;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.App.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository repository;
        private readonly IConfigurationManager configuration;
        private readonly IValidator<Company> validator;

        private int PageSize => configuration.GetValue<int>("Pagination:PageSize");

        public CompanyController(ICompanyRepository repository, IConfigurationManager configuration, IValidator<Company> validator)
        {
            this.repository = repository;
            this.configuration = configuration;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] Guid applicationUserId, int pageIndex, string searchWord)
        {
            var data = await repository.GetAllAsync(applicationUserId, pageIndex, PageSize, searchWord);

            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Company company) 
        {
            var validation = await validator.ValidateAsync(company);

            if (!validation.IsValid) 
                return BadRequest(validation.ToDictionary());
            
            return Ok();            
        }
    }
}
