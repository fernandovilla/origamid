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
    }
}
