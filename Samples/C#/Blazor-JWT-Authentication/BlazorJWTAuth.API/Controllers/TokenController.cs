using Microsoft.AspNetCore.Mvc;

namespace BlazorJWTAuth.API.Controllers
{
    public class TokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
