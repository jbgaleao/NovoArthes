#nullable disable

using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;
using Arthes.DATA.Repositories;
using Arthes.WEB.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arthes.WEB.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly IRepositoryBase<Receita> _repository;
        private readonly IRepositoryBase<Revista> _repositoryRevista;

        public ReceitaController(IRepositoryBase<Receita> repository, IRepositoryBase<Revista> repositoryRevista)
        {
            _repository = repository;
            _repositoryRevista = repositoryRevista;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Receita>> Index()
        {
            IEnumerable<Receita> oListaReceita = RepositoryReceita.GetAllWithDetails();
            return View(oListaReceita);
        }


        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Revista> oListaRevista = _repositoryRevista.GetAll();
            ReceitaVM oNovaReceita = new(oListaRevista);
            return View(oNovaReceita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReceitaVM NovaReceita)
        {
            if (ModelState.IsValid)
            {
                Revista revista = _repositoryRevista.GetById(NovaReceita.IdRevista);
                Receita receita = new()
                {
                    Altura = NovaReceita.Altura,
                    NivelDificuldade = NovaReceita.NivelDificuldade,
                    Nome = NovaReceita.Nome,
                    IdRevista = NovaReceita.IdRevista,
                    IdRevistaNavigation = revista
                };
                _repository.Insert(receita);
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Receita Receita = RepositoryReceita.GetWithDetails((int)id);
            return View(Receita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Receita Receita = RepositoryReceita.GetWithDetails((int)id);
            return View(Receita);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Receita receita = RepositoryReceita.GetWithDetails((int)id);
            IEnumerable<Revista> oListaRevista = _repositoryRevista.GetAll();
            ReceitaVM rvm = new()
            {
                Id = receita.Id,
                Altura = receita.Altura,
                NivelDificuldade = receita.NivelDificuldade,
                Nome = receita.Nome,
                IdRevista = receita.IdRevista,
                Revista = receita.IdRevistaNavigation,
                listaRevista = oListaRevista
            };
            return View(rvm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReceitaVM NovaReceita)
        {
            if (ModelState.IsValid)
            {
                Revista revista = _repositoryRevista.GetById(NovaReceita.IdRevista);
                Receita receita = new()
                {
                    Altura = NovaReceita.Altura,
                    NivelDificuldade = NovaReceita.NivelDificuldade,
                    Nome = NovaReceita.Nome,
                    IdRevista = NovaReceita.Revista.Id,
                    IdRevistaNavigation = revista
                };
                _repository.Update(receita);
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }
    }
}
