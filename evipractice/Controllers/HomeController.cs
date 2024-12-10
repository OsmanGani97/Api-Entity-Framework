using Microsoft.AspNetCore.Mvc;

namespace evipractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
