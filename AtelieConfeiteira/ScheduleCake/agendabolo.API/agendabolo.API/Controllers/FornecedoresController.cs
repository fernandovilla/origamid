using Agendabolo.Core;
using Agendabolo.Core.Fornecedores;
using Agendabolo.Core.LogDeErros;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Linq;
using Agendabolo.Core.Ingredientes;

namespace Agendabolo.Controllers
{
    public class FornecedoresController : BaseController<FornecedorRequest, int>
    {
        private readonly FornecedorService _service = new FornecedorService();

        public override IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid id");

                var fornecedor = _service.GetByID(id);

                if (fornecedor != null)
                {
                    fornecedor.Status = StatusCadastro.Excluido;
                    _service.Save(fornecedor);

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
                var fornecedores = _service.Get()
                    .OrderBy(i => i.Nome)                    
                    .ToList();

                if (fornecedores != null && fornecedores.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = fornecedores
                    });

                return NoContent();

            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult Salvar(FornecedorRequest fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fornecedorDTA = FornecedorRequest.ToDTA(fornecedor);

                    (bool ok, FornecedorDTA result) = _service.Save(fornecedorDTA);

                    if (ok)
                        return Ok(result);
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

        public override IActionResult SelecionarPorId(int id)
        {
            try
            {
                var fornecedor = _service.GetByID(id);

                if (fornecedor != null)
                    return Ok(new
                    {
                        total = 1,
                        data = fornecedor
                    });

                return NotFound("Fornecedor not found");
            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("SelecionarPorNome/{nome}")]
        public IActionResult SelecionarPorNome(string nome)
        {
            try
            {
                var fornecedores = _service.Get()
                    .Where(i => i.Nome.ToUpper().StartsWith(nome.ToUpper()) && i.Status == StatusCadastro.Normal)
                    .OrderBy(i => i.Nome)
                    .ToList();

                if (fornecedores != null && fornecedores.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = fornecedores
                    });

                return NoContent();

            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
