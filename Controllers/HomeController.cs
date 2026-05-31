using Microsoft.AspNetCore.Mvc;

namespace GoMath.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Features()
        {
            return View();
        }
    }
}
