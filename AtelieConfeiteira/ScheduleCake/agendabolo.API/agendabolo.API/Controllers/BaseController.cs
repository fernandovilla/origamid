using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Agendabolo.Controllers
{

    public interface IBaseController<TEntityRequest, TId>
    {
        IActionResult ListarBusca();
        IActionResult SelecionarPorId(TId id);
        IActionResult Salvar(TEntityRequest entity);
        IActionResult Delete(TId id);
        //IActionResult Busca(string key);
    }

    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors("Policy1")]
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

        [HttpGet("Busca/{texto}")]
        public abstract IActionResult Buscar(string texto);
    }
}
