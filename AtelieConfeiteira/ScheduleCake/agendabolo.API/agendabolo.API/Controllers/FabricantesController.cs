using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.Logs;
using Agendabolo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Agendabolo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FabricantesController : ControllerBase
    {
        private readonly FabricanteService _service = new FabricanteService();


        [HttpGet]
        public IActionResult get([FromQuery]int skip = 0, [FromQuery]int take = 20)
        {
            if (take > 500)
                return BadRequest("Max take is 500");

            try
            {
                var total = _service.GetTotal();

                var fabricantes = _service.Get()
                        .OrderBy(i => i.Nome)
                        .ToList()
                        .Skip(skip)
                        .Take(take);

                if (fabricantes != null && fabricantes.Any())
                    return Ok(new { 
                        total,
                        data = fabricantes
                    });

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
                var fabricante = _service.GetByID(id);

                if (fabricante != null)
                    return Ok(fabricante);

                return NotFound("Fabricante não encontrado");
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound("Id não encontrado");
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
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
                    (var ok, var result) = _service.Save(fabricante);

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
        public IActionResult put(FabricanteRequest fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    (var ok, var result) = _service.Save(fabricante);

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
                if (id > 0)
                {
                    var result = _service.Delete(id);

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
