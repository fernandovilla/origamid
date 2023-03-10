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

        [HttpGet]
        public IActionResult get([FromQuery] int skip = 0, [FromQuery] int take = 20)
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


        [HttpGet("{id}")]
        public IActionResult get(ulong id)
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
        public IActionResult get(string nome)
        {
            return null;
        }
    }
}
