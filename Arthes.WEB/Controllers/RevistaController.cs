using Arthes.DATA.Models;
using Arthes.DATA.Services;

using Microsoft.AspNetCore.Mvc;

namespace Arthes.WEB.Controllers
{
    public class RevistaController : Controller
    {
        private RevistaService oRevistaService = new RevistaService();

        public IActionResult Index()
        {
            List<Revista> oListaRevista = oRevistaService.oRepositoryRevista.GetAll();
            return View(oListaRevista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Revista rev)
        {
            oRevistaService.oRepositoryRevista.Insert(rev);
            return RedirectToAction("Index");
        }
    }
}
