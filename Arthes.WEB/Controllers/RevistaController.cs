using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;


using Microsoft.AspNetCore.Mvc;

namespace Arthes.WEB.Controllers
{
    public class RevistaController : Controller
    {
        private readonly IRepositoryRevista _repository;
        public RevistaController(IRepositoryRevista repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revista>>> Index()
        {
            IEnumerable<Revista>? oListaRevista = await _repository.GetAll();
            return View(oListaRevista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Revista revista)
        {
            if (ModelState.IsValid)
            {
                await _repository.Insert(revista);
                return RedirectToAction(nameof(Index));
            }

            return View("Index");
        }

       

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            Revista revista = await _repository.GetById(id);
            return View(revista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Revista revista = await _repository.GetById(id);
            return View(revista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Revista revista)
        {                
            if (ModelState.IsValid)
            {
                await _repository.Update(revista);
                return RedirectToAction(nameof(Index));
            }

            return View( "Edit",revista);
        }
    }
}
