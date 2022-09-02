using Agendabolo.Core.Insumos;
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
    public class InsumosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly InsumoService _service;

        public InsumosController([FromServices] ApplicationDbContext context)
        {
            _context = context;
            _service = new InsumoService(context);
        }


        [HttpGet]
        public IActionResult get([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            if (take > 500)
                return BadRequest("Max take is 500");

            try
            {
                var total = _service.GetTotal();

                var insumos = _service.Get()
                        .ToList()
                        .Skip(skip)
                        .Take(take);


                if (insumos != null && insumos.Any())
                    return Ok(new
                    {
                        total,
                        data = insumos
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
                var ingrediente = _service.GetById(id);

                if (ingrediente != null)
                    return Ok(ingrediente);

                return NotFound("Insumo not found");
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
                    (bool ok, Insumo result) = _service.Save(insumo);

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
        public IActionResult put(InsumoRequest insumo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    (bool ok, Insumo result) = _service.Save(insumo);

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
