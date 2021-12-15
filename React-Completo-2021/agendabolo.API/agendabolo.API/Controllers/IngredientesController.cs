using Sistema.Models.Ingredientes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Sistema.Models.Logs;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientesController : ControllerBase
    {
        public IActionResult get()
        {
            try
            {
                var service = new IngredienteService();

                var ingredientes = service.Select();

                if (ingredientes != null && ingredientes.Any())
                    return Ok(ingredientes);

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
                var service = new IngredienteService();

                var ingrediente = service.Select(id);

                if (ingrediente != null)
                    return Ok(ingrediente);

                return NoContent();
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
                    var service = new IngredienteService();
                    var result = service.Save(ingrediente);

                    if (result.Item1)
                        return Ok(result.Item2);
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
