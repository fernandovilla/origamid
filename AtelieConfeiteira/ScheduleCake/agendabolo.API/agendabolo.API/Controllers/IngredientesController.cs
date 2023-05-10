using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.Logs;
using Agendabolo.Data;
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
    public class IngredientesController : ControllerBase
    {
        private readonly IngredienteService _service = new IngredienteService();


        [HttpGet]
        public IActionResult get([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            if (take > 1000)
                return BadRequest("Max take is 1000");

            try
            {
                var ingredientes = _service.Get()
                        .ToList()
                        .OrderBy(i => i.Nome)
                        .Skip(skip)
                        .Take(take);

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
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("BuscaPorNome/{nome}")]
        public IActionResult get(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return BadRequest("Informe ao menos 3 caracteres para realizar a busca");

            try
            {                
                var ingredientes = _service.Get()
                    .Where(i => i.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(i => i.Nome)
                    .ToList();

                if (ingredientes != null && ingredientes.Any())
                    return Ok(new
                    {
                        total = ingredientes.Count(),
                        data = ingredientes
                    });

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        //[HttpGet("BuscaPorNome/{nome}/{skip}/{take}")]
        [HttpGet("BuscaPorNomeSkip")]
        public IActionResult getByNameSkip([FromQuery] string nome, [FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            if (string.IsNullOrEmpty(nome))
                return BadRequest("Informe ao menos 3 caracteres para realizar a busca");

            try
            {
                var ingredientes = _service.Get().Where(i => i.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase));
                int total = ingredientes.Count();


                IEnumerable<IngredienteDTA> ingredientesResult;
                if (ingredientes.Count() < skip || ingredientes.Count() < take)
                {
                    ingredientesResult = ingredientes
                        .OrderBy(i => i.Nome)
                        .ToList();
                    
                } else
                {
                    ingredientesResult = ingredientes
                        .Skip(skip)
                        .Take(take)
                        .OrderBy(i => i.Nome)
                        .ToList();
                }
                

                if (ingredientesResult != null && ingredientesResult.Any())
                    return Ok(new
                    {
                        total = total,
                        data = ingredientesResult
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
        public IActionResult get(ulong id)
        {
            try
            {
                var ingrediente = _service.GetByID(id);

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
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpPost]
        public IActionResult post(IngredienteRequest ingrediente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    (bool ok, IngredienteDTA result) = _service.Save(ingrediente);

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
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult put(IngredienteRequest ingrediente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    (bool ok, IngredienteDTA result) = _service.Save(ingrediente);

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
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult delete(ulong id)
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
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


    }
}
