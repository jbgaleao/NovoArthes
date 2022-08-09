#nullable disable

using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;
using Arthes.DATA.Models.Enum;
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
            //RepositoryReceita repositoryReceita = new(null, true);
            IEnumerable<Receita> oListaReceita = RepositoryReceita.GetAllWithDetails();
            return View(oListaReceita);
        }


        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Revista> oListaRevista = _repositoryRevista.GetAll();
            NovaReceitaViewModel oNovaReceita = new NovaReceitaViewModel(oListaRevista);
            return View(oNovaReceita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NovaReceitaViewModel NovaReceita)
        {
            if (ModelState.IsValid)
            {
                Revista revista = _repositoryRevista.GetById(NovaReceita.IdRevista);
                Receita receita = new()
                {
                    Altura = NovaReceita.Altura,
                    NivelDificuldade = (NivelDificuldade)NovaReceita.NivelDificuldade,
                    Nome = NovaReceita.Nome,
                    IdRevista = NovaReceita.IdRevista,
                    IdRevistaNavigation = revista
                };
                _repository.Insert(receita);
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

    }
}
