using Microsoft.AspNetCore.Mvc;

namespace Gestao.App.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
