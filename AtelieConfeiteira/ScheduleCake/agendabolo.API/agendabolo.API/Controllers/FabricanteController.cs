using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Logs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace Agendabolo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FabricanteController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            try
            {
                var service = new FabricanteService();

                var fabricantes = service.Select();

                if (fabricantes != null && fabricantes.Any())
                    return Ok(fabricantes);

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult get(ulong id)
        {
            try
            {
                var service = new FabricanteService();

                var fabricante = service.Select(id);

                if (fabricante != null)
                    return Ok(fabricante);

                return NotFound("Fabricante não encontrado");
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult post(FabricanteRequest fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new FabricanteService();
                    var result = service.Save(fabricante);

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
        public IActionResult put(FabricanteRequest fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new FabricanteService();
                    var result = service.Save(fabricante);

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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult delete(ulong id)
        {
            try
            {
                if (id > 0)
                {
                    var service = new FabricanteService();
                    var result = service.Delete(id);

                    if (result)
                        return Ok();
                    else
                        return BadRequest();
                }
                else
                {
                    return BadRequest("Invalid ID");
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
