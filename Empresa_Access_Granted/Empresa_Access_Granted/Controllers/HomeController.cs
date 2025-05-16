using Microsoft.AspNetCore.Mvc;

namespace Empresa_Access_Granted.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
