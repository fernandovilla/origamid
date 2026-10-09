using Gestao.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.App.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly ICategoryRepository repository;
        private readonly IConfigurationManager configuration;

        private int PageSize => configuration.GetValue<int>("Pagination:PageSize");

        public ClientController(ICategoryRepository repository, IConfigurationManager configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }
    }
}
