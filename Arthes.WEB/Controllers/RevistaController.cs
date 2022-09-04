#nullable disable
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;
using Arthes.DATA.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace Arthes.WEB.Controllers
{
    public class RevistaController : Controller
    {
        private readonly IRepositoryBase<Revista> _repository;


        public RevistaController(IRepositoryBase<Revista> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Revista>> Index()
        {
            IEnumerable<Revista>? oListaRevista = _repository.GetAll();
            return View(oListaRevista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Revista revista)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(revista);
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

            Revista revista = _repository.GetById(id);

            return revista == null ? NotFound() : View(revista);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Revista revista = _repository.GetById(id);
            return View(revista);
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
            Revista revista = _repository.GetById(id);
            return View(revista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Revista revista)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(revista);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", revista);
        }


        [HttpGet]
        private IActionResult ListaReceitasPorRevistaId(int id)
        {
            IEnumerable<Receita> oListaReceita = RepositoryReceita.GetAllWithDetails(id);
            return View(oListaReceita);
        }
    }
}
