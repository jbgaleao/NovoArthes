using Microsoft.AspNetCore.Mvc;

namespace Arthes.WEB.Views.Revista
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
