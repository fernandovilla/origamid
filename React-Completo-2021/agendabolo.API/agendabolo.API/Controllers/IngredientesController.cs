using agendabolo.Models.Ingredientes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agendabolo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientesController : ControllerBase
    {
        public IActionResult get()
        {
            return Ok(new Ingrediente() { Id = 1, Nome = "Farinha de Trigo", PrecoCusto = 2.50m });
        }


        [HttpPost]
        public IActionResult post(Ingrediente ingrediente)
        {



            return Ok();
        }
    }
}
