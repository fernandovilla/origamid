using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ranek_webapi.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ranek_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Policy1")]
    public class ProdutoController : ControllerBase
    {        
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
        }


        [HttpGet]        
        public IEnumerable<Produto> Get()
        {
            var repository = new ProdutoRepository();
            return repository.Selecionar();
        }



    }
}
