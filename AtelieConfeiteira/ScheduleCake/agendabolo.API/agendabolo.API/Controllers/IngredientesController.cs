using Agendabolo.Core;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.LogDeErros;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Linq;
using System.Net;

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

                var ingrediente = _service.Get(id);

                if (ingrediente != null)
                {
                    ingrediente.Status = StatusCadastroEnum.Excluido;
                    _service.Save(ingrediente);

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu erro deletando ingreidnte - Id: {id}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult ListarBusca()
        {
            try
            {
                var ingredientes = _service.Get()
                    .OrderBy(i => i.Nome)
                    .Select(i => new IngredienteBuscaResponse { 
                        Id = i.Id, 
                        Nome = i.Nome, 
                        EstoqueTotal = i.EstoqueTotal, 
                        Marca = i.Marca, 
                        Status = (int)i.Status,
                        Tipo = (int)i.Tipo
                    }).ToList();

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
                Log.Error(ex, "Ocorreu erro listando ingredientes");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("Ativos")]
        public IActionResult ListarBuscaAtivos()
        {
            try
            {
                var ingredientes = _service.Get()
                    .Where(i => i.Status == StatusCadastroEnum.Normal)
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
                Log.Error(ex, "Ocorreu erro listando ingredientes ativos");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("Busca/{texto}")]
        public override IActionResult Buscar(string texto)
        {
            return Buscar(-1, texto);
        }

        [HttpGet("Busca/{tipo}/{texto}")]
        public IActionResult Buscar(int tipo, string texto)
        {
            try
            {
                var ingredientes = _service.GetWithEmbalagens()
                    .Where(i => i.Status == StatusCadastroEnum.Normal &&
                        (
                            i.Nome.ToUpper().StartsWith(texto.ToUpper()) ||
                            i.Id.ToString().Equals(texto) ||
                            i.Embalagens.Where(e => e.EAN.Equals(texto)).Any())
                        );

                if (tipo > 0)
                    ingredientes = ingredientes.Where(i => i.Tipo == (TipoIngrediente)tipo);

                ingredientes = ingredientes
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
                Log.Error(ex, $"Ocorreu erro buscando ingredientes - tipo: {tipo}, texto: {texto}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("BuscaKey/{key}")]
        public IActionResult BuscarKey(string key)
        {
            try
            {
                var ingredientes = _service.Get()
                    .Where(i => (
                        i.Nome.ToUpper().Contains(key.ToUpper()) ||
                        i.Id.ToString() == key.ToUpper() ||
                        i.Embalagens.Where(e => e.EAN.Equals(key)).Any()) &&
                        i.Status == StatusCadastroEnum.Normal)
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
                Log.Error(ex, $"Ocorreu erro buscando ingredientes - Key: {key}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult SelecionarPorId(int id)
        {
            try
            {
                var ingrediente = _service
                    .Get(id);

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
                Log.Error(ex, $"Ocorreu erro buscando ingredientes - Id: {id}");
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
                Log.Error(ex, $"Ocorreu erro salvando ingrediente");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
