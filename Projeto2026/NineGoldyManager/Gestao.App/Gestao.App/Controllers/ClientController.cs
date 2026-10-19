using Gestao.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.App.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController(IConfigurationManager Configuration) : Controller
    {
        //private readonly ICategoryRepository repository;
        

        private int PageSize => Configuration.GetValue<int>("Pagination:PageSize");

        //public ClientController(ICategoryRepository repository, IConfigurationManager configuration)
        //{
        //    this.repository = repository;
        //    this.configuration = configuration;
        //}
    }
}
