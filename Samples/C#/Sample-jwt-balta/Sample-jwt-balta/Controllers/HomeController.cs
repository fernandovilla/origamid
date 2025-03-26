using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sample_jwt_balta.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private string? CurrentUserName => User.FindFirst(ClaimTypes.Name)?.Value;

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonimous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Usuário Autenticado: '{CurrentUserName}'";

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "Admin, Employee")]
        public string Employee() => "Funcionário logado";

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public string Admin() => "Admin logado";
    }
}
