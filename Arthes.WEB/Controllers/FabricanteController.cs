using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arthes.WEB.Controllers
{
    public class FabricanteController : Controller
    {

        private readonly IRepositoryBase<Fabricante> _repository;

        public FabricanteController(IRepositoryBase<Fabricante> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fabricante>> Index()
        {
            IEnumerable<Fabricante>? oFabricante = _repository.GetAll();
            return View(oFabricante);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(fabricante);
                return RedirectToAction(nameof(Index));
            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fabricante fabricante = _repository.GetById(id);

            return fabricante == null ? NotFound() : View(fabricante);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Fabricante tipoLinha = _repository.GetById(id);
            return View(tipoLinha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Fabricante tipoLinha = _repository.GetById(id);
            return View(tipoLinha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(fabricante);
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", fabricante);
        }
    }
}
