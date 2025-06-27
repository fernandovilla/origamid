using Agendabolo.Core;
using Agendabolo.Core.Entradas;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.LogDeErros;
using Agendabolo.Core.Produtos;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Linq;
using System.Net;

namespace Agendabolo.Controllers
{
    public class EntradasController : BaseController<EntradaRequest, int>
    {
        private readonly EntradaService _service = new EntradaService();
        private readonly IngredienteService _ingredienteService = new IngredienteService();
        private readonly ProdutoService _produtoService = new ProdutoService();

        public override IActionResult Buscar(string texto)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("BuscaItem/{texto}")]
        public IActionResult BuscarItem(string texto)
        {
            try
            {
                var ingredientes = _ingredienteService.GetWithEmbalagens()
                    .Where(i => i.Status == StatusCadastroEnum.Normal &&
                        (
                            i.Nome.ToUpper().StartsWith(texto.ToUpper()) ||
                            i.Id.ToString().Equals(texto) ||
                            i.Embalagens.Where(e => e.EAN.Equals(texto)).Any())
                        );


                ingredientes = ingredientes
                    .OrderBy(i => i.Nome)
                    .ToList();

                if (ingredientes != null && ingredientes.Any())
                    return Ok(new
                    {
                        total = _service.GetTotal(),
                        data = ingredientes
                    });

                return NoContent();

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu erro buscando ingredientes - texto: {texto}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }



            return BadRequest();
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
