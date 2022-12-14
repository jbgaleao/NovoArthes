using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arthes.WEB.Controllers
{
    public class TipoLinhaController : Controller
    {

        private readonly IRepositoryBase<TipoLinha> _repository;

        public TipoLinhaController(IRepositoryBase<TipoLinha> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoLinha>> Index()
        {
            IEnumerable<TipoLinha>? oTipoLinha = _repository.GetAll();
            return View(oTipoLinha);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoLinha tipoLinha)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(tipoLinha);
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

            TipoLinha tipoLinha = _repository.GetById(id);

            return tipoLinha == null ? NotFound() : View(tipoLinha);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            TipoLinha tipoLinha = _repository.GetById(id);
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
            TipoLinha tipoLinha = _repository.GetById(id);
            return View(tipoLinha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TipoLinha tipolinha)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(tipolinha);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", tipolinha);
        }










    }
}
