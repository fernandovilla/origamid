﻿using Agendabolo.Core.Clientes;
using Agendabolo.Core.LogDeErros;
using Agendabolo.Core.Produtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Linq;
using Agendabolo.Core;
using Agendabolo.Core.Pessoas;

namespace Agendabolo.Controllers
{    
    public class ClientesController : BaseController<ClienteRequest, int>
    {
        private readonly ClienteService _service = new ClienteService();


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
                var clientes = _service.Get()
                    .Select(i => new BuscaBaseResponse { Id = i.Id, Nome = i.Nome, Status = (int)i.Status, Tipo = (int)i.TipoPessoa })
                    .OrderBy(i => i.Nome)
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
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult SelecionarPorId(int id)
        {
            try
            {
                var cliente = _service.Get(id);

                if (cliente != null)
                    return Ok(new
                    {
                        total = 1,
                        data = cliente
                    });

                return NoContent();
            }
            catch (Exception ex)
            {
                LogDeErro.Default.Write(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public override IActionResult Salvar(ClienteRequest cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    (bool ok, PessoaDTA result) = _service.Save(cliente);

                    if (ok)
                        return Ok((ClienteRequest)_service.Get(result.Id));
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

        public override IActionResult Buscar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
