using Agendabolo.Core.Logs;
using Agendabolo.Core.Produtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Agendabolo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _service = new ProdutoService();


        [HttpGet("ListaBusca")]
        public IActionResult ListarProdutosBusca()
        {
            try
            {
                var produtos = _service.Get()
                    .OrderBy(i => i.Nome)
                    .Select(i => new ProdutoBuscaResponse {  Id = i.Id, Nome = i.Nome, Status = i.Status})
                    .ToList();
                    
                if (produtos != null && produtos.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = produtos
                    });

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpGet("{id}")]
        public IActionResult SelectById(ulong id)
        {
            try
            {
                var produto = _service.GetByID(id);

                if (produto != null)
                    return Ok(new
                    {
                        total = 1,
                        data = produto
                    }); ;

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


    }
}
