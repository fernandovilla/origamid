using Agendabolo.Core.Logs;
using Agendabolo.Core.Receitas;
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
    public class ReceitasController : ControllerBase
    {
        private readonly ReceitaService _service = new ReceitaService();

        [HttpGet("Listar")]
        public IActionResult Listar([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            if (take > 500)
                return BadRequest("Max take is 500");

            try
            {
                var total = _service.GetTotal();

                var receitas = _service.Get()
                    .OrderBy(i => i.Nome)
                    .ToList()
                    .Skip(skip)
                    .Take(take);



                if (receitas != null && receitas.Any())
                    return Ok(new
                    {
                        total,
                        data = receitas
                    });

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult SelecionarPorId(ulong id)
        {
            try
            {
                var receita = _service.GetByID(id);

                if (receita != null)
                    return Ok(new
                    {
                        total = 1,
                        data = receita
                    });

                return NotFound("Receita not found");
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("BuscaPorNome/{nome}")]
        public IActionResult SelecionarPorNome(string nome)
        {
            return null;
        }

        [HttpPost]
        public IActionResult post(ReceitaRequest receita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //(bool ok, Ingrediente result) = _service.Save(ingrediente);

                    //if (ok)
                    //    return Ok(result);
                    //else
                    //    return BadRequest();

                    return Ok();
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
