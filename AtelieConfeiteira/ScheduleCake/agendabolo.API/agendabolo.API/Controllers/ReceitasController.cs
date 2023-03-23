using Agendabolo.Core.Logs;
using Agendabolo.Core.Receitas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

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
            if (take > 1000)
                return BadRequest("Max take is 1000");

            try
            {
                var total = _service.GetTotal();

                var receitas = _service.Get()
                    .OrderBy(i => i.Nome)
                    .ToList()
                    .Skip(skip)
                    .Take(take)
                    .Select(i => ReceitaRequest.Parse(i));

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
                        data = ReceitaRequest.Parse(receita)
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

        [HttpPut]
        [HttpPost]
        public IActionResult Salvar(ReceitaRequest receita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var receitaDta = ReceitaDTA.Parse(receita);

                    (bool ok, ReceitaDTA result) = _service.Save(receitaDta);

                    if (ok)
                        return Ok(ReceitaRequest.Parse(result));
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

        
        //public IActionResult Alterar(ReceitaRequest receita)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var receitaDta = Receita.Parse(receita);

        //            (bool ok, Receita result) = _service.Save(receitaDta);

        //            if (ok)
        //                return Ok(result);
        //            else
        //                return BadRequest();
        //        }
        //        else
        //        {
        //            return BadRequest(ModelState);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogDeErros.Default.Write(ex);
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}
    }
}
