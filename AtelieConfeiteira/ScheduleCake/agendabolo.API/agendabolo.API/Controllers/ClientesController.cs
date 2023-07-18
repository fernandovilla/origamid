using Agendabolo.Core.Clientes;
using Agendabolo.Core.Logs;
using Agendabolo.Core.Produtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Linq;

namespace Agendabolo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service = new ClienteService();

        [HttpGet("ListaBusca")]
        public IActionResult ListarClientesBusca()
        {
            try
            {
                var clientes = _service.Get()
                    .OrderBy(i => i.Nome)
                    .Select(i => new ClienteBuscaResponse { Id = i.Id, Nome = i.Nome, Status = (int)i.Status })
                    .ToList();

                if (clientes != null && clientes.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = clientes
                    });

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
