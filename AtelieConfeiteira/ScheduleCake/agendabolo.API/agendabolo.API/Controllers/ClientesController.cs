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

        [HttpGet("{id}")]
        public IActionResult SelectById(int id)
        {
            try
            {
                var cliente = _service.GetByID(id);

                if (cliente != null)
                    return Ok(new
                    {
                        total = 1,
                        data = ClienteRequest.ParseFromDTA(cliente)
                    }); ; ; ;

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [HttpPost]
        public IActionResult Salvar(ClienteRequest cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clienteDTA = ClienteRequest.ParseToDTA(cliente);

                    (bool ok, ClienteDTA result) = _service.Save(clienteDTA);

                    if (ok)
                        return Ok(ClienteRequest.ParseFromDTA(_service.GetByID(result.Id)));
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
