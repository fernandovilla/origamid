using Agendabolo.Core.Logs;
using Agendabolo.Core.Produtos;
using Agendabolo.Core.Receitas;
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
                    .Select(i => new ProdutoBuscaResponse { Id = i.Id, Nome = i.Nome, Status = i.Status })
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

        [HttpGet("ListaBusca2")]
        public IEnumerable<ProdutoBuscaResponse> ListarProdutosBusca2()
        {
            try
            {
                var produtos = _service.Get()
                    .OrderBy(i => i.Nome)
                    .Select(i => new ProdutoBuscaResponse { Id = i.Id, Nome = i.Nome, Status = i.Status });

                if (produtos != null && produtos.Any())
                    return produtos;

                return null;
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return null;
            }
        }


        [HttpGet("{id}")]
        public IActionResult SelectById(int id)
        {
            try
            {
                var produto = _service.GetByID(id);

                if (produto != null)
                    return Ok(new
                    {
                        total = 1,
                        data = ProdutoRequest.ParseFromDTA(produto)
                    }); ;

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpGet("Min/{id}")]
        public IActionResult SelectById_Minino(int id)
        {
            try
            {
                var produto = _service.GetByID_Min(id);

                if (produto != null)
                    return Ok(new
                    {
                        total = 1,
                        data = ProdutoRequest.ParseFromDTA(produto)
                    }); ;

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpPut]
        [HttpPost]
        public IActionResult Salvar(ProdutoRequest produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produtoDTA = ProdutoRequest.ParseToDTA(produto);

                    (bool ok, ProdutoDTA result) = _service.Save(produtoDTA);

                    if (ok)
                        return Ok(ProdutoRequest.ParseFromDTA(_service.GetByID(result.Id)));
                    else
                        return BadRequest();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
