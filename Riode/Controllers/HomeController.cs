using Microsoft.AspNetCore.Mvc;

namespace Riode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}