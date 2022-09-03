using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;
using Arthes.DATA.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace Arthes.WEB.Controllers
{
    public class FabricanteController : Controller
    {
        public string Mensagem { get; set; }
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
            Fabricante fabricante = _repository.GetById(id);
            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (RepositoryFabricante.TemLinhaAssociada(id))
            {
                ModelState.AddModelError("Nome", "Existe(m) Linha(s) associada(s) a este Fabricante.");
                return RedirectToAction("Delete", id);
            }
            else
            {
                _repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Fabricante fabricante = _repository.GetById(id);
            return View(fabricante);
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
