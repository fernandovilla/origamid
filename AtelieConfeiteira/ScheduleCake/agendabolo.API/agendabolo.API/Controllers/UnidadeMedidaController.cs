using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.LogDeErros;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Linq;
using Agendabolo.Core;

namespace Agendabolo.Controllers
{
    public class UnidadeMedidaController : BaseController<UnidadeMedidaDTA, int>
    {
        private readonly UnidadeMedidaService _service = new UnidadeMedidaService();

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
                var unidadesMedida = _service.Get()
                    .OrderBy(i => i.Abreviada)
                    .Select(i => new BuscaBaseResponse { Id = i.Id, Nome = $"{i.Descricao} ({i.Abreviada})" })
                    .ToList();

                if (unidadesMedida != null && unidadesMedida.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = unidadesMedida
                    });

                return NoContent();

            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult Salvar(UnidadeMedidaDTA entity)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult SelecionarPorId(int id)
        {
            try
            {
                var unidadeMedida = _service
                    .GetByID(id);

                if (unidadeMedida != null)
                    return Ok(new
                    {
                        total = 1,
                        data = unidadeMedida
                    });

                return NotFound("Ingrediente not found");
            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
