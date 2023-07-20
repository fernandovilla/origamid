using Agendabolo.Core.Logs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;

namespace Agendabolo.Controllers
{
    
    public interface IBaseController<TEntityRequest, TId>
    {
        IActionResult ListarBusca();
        IActionResult SelecionarPorId(TId id);
        IActionResult Salvar(TEntityRequest entity);
        IActionResult Delete(TId id);        
    }

    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController<TEntityRequest, TId> : 
        ControllerBase, 
        IBaseController<TEntityRequest, TId>
    {
        [HttpDelete("{id}")]
        public abstract IActionResult Delete(TId id);

        [HttpGet]
        public abstract IActionResult ListarBusca();

        [HttpGet("{id}")]
        public abstract IActionResult SelecionarPorId(TId id);

        [HttpPost]
        [HttpPut]
        public abstract IActionResult Salvar(TEntityRequest entity);        
    }
}
