using Agendabolo.Core.LogDeErros;
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
    public class ProdutosController : BaseController<ProdutoRequest, int>
    {
        private readonly ProdutoService _service = new ProdutoService();

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
                LogDeErro.Default.Write(ex);
                return null;
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
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        public override IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid id");

                var produto = _service.GetByID(id);

                if (produto != null)
                {
                    produto.Status = Core.StatusCadastro.Excluido;
                    _service.Save(produto);

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult ListarBusca()
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
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult SelecionarPorId(int id)
        {
            try
            {
                var produto = _service.GetByID(id);

                //Calcular custo receita/item

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
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult Salvar(ProdutoRequest produto)
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
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
