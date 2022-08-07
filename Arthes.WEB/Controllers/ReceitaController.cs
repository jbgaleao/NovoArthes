using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arthes.WEB.Controllers
{
    public class ReceitaController : Controller
    {

        private readonly IRepositoryReceita _repository;

        public ReceitaController(IRepositoryReceita repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> Index()
        {
            IEnumerable<Receita>? oListaReceita = await _repository.GetAllWithRevista();
            return View(oListaReceita);
        }
      
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Receita receita)
        {
            if (ModelState.IsValid)
            {
                await _repository.Insert(receita);
                return RedirectToAction(nameof(Index));
            }

            return View("Index");
        }


 [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            Receita receita = await _repository.GetById(id);

            return receita == null ? NotFound() : View(receita);
        }
















    }
}
