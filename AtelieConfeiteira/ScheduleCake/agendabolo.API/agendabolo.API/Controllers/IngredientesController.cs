using Agendabolo.Core;
using Agendabolo.Core.Clientes;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.LogDeErros;
using Agendabolo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Agendabolo.Controllers
{
    public class IngredientesController : BaseController<IngredienteRequest, int>
    {
        private readonly IngredienteService _service = new IngredienteService();


        //[HttpGet("BuscaSkip")]
        //public IActionResult get([FromQuery] int skip = 0, [FromQuery] int take = 20)
        //{
        //    if (take > 1000)
        //        return BadRequest("Max take is 1000");

        //    try
        //    {
        //        var ingredientes = _service.Get()
        //                .ToList()
        //                .OrderBy(i => i.Nome)
        //                .Skip(skip)
        //                .Take(take);

        //        if (ingredientes != null && ingredientes.Any())
        //            return Ok(new
        //            {
        //                total = _service.GetTotal(),
        //                data = ingredientes
        //            });

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogDeErros.Default.Write(ex);
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}

        //[HttpGet("BuscaPorNome/{nome}")]
        //public IActionResult get(string nome)
        //{
        //    if (string.IsNullOrEmpty(nome))
        //        return BadRequest("Informe ao menos 3 caracteres para realizar a busca");

        //    try
        //    {
        //        var ingredientes = _service.Get()
        //            .Where(i => i.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase))
        //            .OrderBy(i => i.Nome)
        //            .ToList();

        //        if (ingredientes != null && ingredientes.Any())
        //            return Ok(new
        //            {
        //                total = ingredientes.Count(),
        //                data = ingredientes
        //            });

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogDeErros.Default.Write(ex);
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}


        ////[HttpGet("BuscaPorNome/{nome}/{skip}/{take}")]
        //[HttpGet("BuscaPorNomeSkip")]
        //public IActionResult getByNameSkip([FromQuery] string nome, [FromQuery] int skip = 0, [FromQuery] int take = 20)
        //{
        //    if (string.IsNullOrEmpty(nome))
        //        return BadRequest("Informe ao menos 3 caracteres para realizar a busca");

        //    try
        //    {
        //        var ingredientes = _service.Get().Where(i => i.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase));
        //        int total = ingredientes.Count();


        //        IEnumerable<IngredienteDTA> ingredientesResult;
        //        if (ingredientes.Count() < skip || ingredientes.Count() < take)
        //        {
        //            ingredientesResult = ingredientes
        //                .OrderBy(i => i.Nome)
        //                .ToList();

        //        }
        //        else
        //        {
        //            ingredientesResult = ingredientes
        //                .Skip(skip)
        //                .Take(take)
        //                .OrderBy(i => i.Nome)
        //                .ToList();
        //        }


        //        if (ingredientesResult != null && ingredientesResult.Any())
        //            return Ok(new
        //            {
        //                total = total,
        //                data = ingredientesResult
        //            });

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogDeErros.Default.Write(ex);
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}


        public override IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid id");

                var ok = _service.Delete(id);

                if (ok)
                    return Ok();
                else
                    return BadRequest();
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
                var ingredientes = _service.Get()
                    .OrderBy(i => i.Nome)
                    .Select(i => new IngredienteBuscaResponse { Id = i.Id, Nome = i.Nome, EstoqueTotal = i.EstoqueTotal, Marca = i.Marca,  Status = (int)i.Status })
                    .ToList();

                if (ingredientes != null && ingredientes.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = ingredientes
                    });

                return NoContent();

            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("Ativos")]
        public IActionResult ListarBuscaAtivos()
        {
            try
            {
                var ingredientes = _service.Get()
                    .Where(i => i.Status == StatusCadastro.Normal)
                    .OrderBy(i => i.Nome)
                    .Select(i => new BuscaBaseResponse { Id = i.Id, Nome = i.Nome, Status = (int)i.Status })
                    .ToList();

                if (ingredientes != null && ingredientes.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = ingredientes
                    });

                return NoContent();

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
                var ingredientes = _service.Get()
                    .Where(i => i.Nome.ToUpper().StartsWith(nome.ToUpper()) && i.Status == StatusCadastro.Normal)
                    .OrderBy(i => i.Nome)
                    .ToList();

                if (ingredientes != null && ingredientes.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = ingredientes
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
                var ingrediente = _service
                    .GetByID(id);

                if (ingrediente != null)
                    return Ok(new
                    {
                        total = 1,
                        data = ingrediente
                    });

                return NotFound("Ingrediente not found");
            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult Salvar(IngredienteRequest ingrediente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ingredienteDTA = IngredienteRequest.ToDTA(ingrediente);

                    (bool ok, IngredienteDTA result) = _service.Save(ingredienteDTA);

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

        [HttpGet("Teste")]
        public IActionResult Teste()
        {
            return Ok("TESTE OK");
        }
    }
}
