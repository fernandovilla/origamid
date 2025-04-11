using Agendabolo.Core.Entradas;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.LogDeErros;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;

namespace Agendabolo.Controllers
{
    public class EntradaController : BaseController<EntradaRequest, int>
    {
        private readonly EntradaService _service = new EntradaService();

        public override IActionResult Buscar(string texto)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult ListarBusca()
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Salvar(EntradaRequest entradaRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entradaDTA = EntradaRequest.ToDTA(entradaRequest);

                    (bool ok, EntradaDTA result) = _service.Save(entradaDTA);

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
            throw new System.NotImplementedException();
        }
    }
}
