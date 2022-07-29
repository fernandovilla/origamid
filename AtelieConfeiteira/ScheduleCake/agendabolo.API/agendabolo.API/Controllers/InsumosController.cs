using Agendabolo.Core.Insumos;
using Agendabolo.Core.Logs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace Agendabolo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InsumosController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            try
            {
                var service = new InsumoService();

                var insumos = service.Select();

                if (insumos != null && insumos.Any())
                    return Ok(insumos);

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
                var service = new InsumoService();

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
        public IActionResult post(InsumoRequest insumo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new InsumoService();
                    var result = service.Save(insumo);

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

        [HttpPut]
        public IActionResult put(InsumoRequest insumo)
        {
            return BadRequest();
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult delete(ulong id)
        {
            return BadRequest();
        }


    }
}
