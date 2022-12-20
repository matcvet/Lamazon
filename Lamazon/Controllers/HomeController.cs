using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
