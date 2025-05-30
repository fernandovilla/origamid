using Agendabolo.Core.Formas;
using Agendabolo.Core.LogDeErros;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using Agendabolo.Core.Ingredientes;
using System.Linq;

namespace Agendabolo.Controllers
{
    public class FormasController : BaseController<FormaRequest, int>
    {
        private readonly FormaService _service = new FormaService();

        public override IActionResult Buscar(string texto)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Delete(int id)
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
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult ListarBusca()
        {
            try
            {
                var formas = _service.Get()
                    .OrderBy(i => i.Descricao)
                    .Select(i => new FormaBuscaResponse { Id = i.Id, Nome = i.Descricao, Status = (int)i.Status })
                    .ToList();

                if (formas != null && formas.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = formas
                    });

                return NoContent();

            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult Salvar(FormaRequest formaRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    (bool ok, FormaDTA result) = _service.Save(formaRequest);

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
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult SelecionarPorId(int id)
        {
            try
            {
                var forma = _service
                    .Get(id);

                if (forma != null)
                    return Ok(new
                    {
                        total = 1,
                        data = forma
                    });

                return NotFound("Forma not found");
            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
