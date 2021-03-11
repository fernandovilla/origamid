using Microsoft.AspNetCore.Mvc;
using Sistema.Models.Core.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaSoft.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return List(0, 20);
        }

        

        [HttpGet("{id}")]
        public ActionResult<Produto> Consulta(long id)
        {
            return Ok(new Produto());
        }
        

        [HttpGet("{step}/{registros}")]
        public ActionResult List(int step, int registros)
        {
            return null;
        }


        [HttpPost]
        public ActionResult<Produto> Create(Produto produto)
        {
            produto.Id = 1;
            return Ok(produto);
        }

        //alteração
        //exclusão




    }
}
