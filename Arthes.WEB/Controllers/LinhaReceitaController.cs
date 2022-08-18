#nullable disable

using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;
using Arthes.DATA.Repositories;
using Arthes.WEB.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arthes.WEB.Controllers
{
    public class LinhaReceitaController : Controller
    {

        private readonly IRepositoryBase<LinhaReceita> _repository;
        private readonly IRepositoryBase<Receita> _repositoryReceita;
        private readonly IRepositoryBase<Linha> _repositoryLinha;

        public LinhaReceitaController(IRepositoryBase<LinhaReceita> repository, IRepositoryBase<Receita> repositoryReceita, IRepositoryBase<Linha> repositoryLinha)
        {
            _repository = repository;
            _repositoryReceita = repositoryReceita;
            _repositoryLinha = repositoryLinha;
        }

        public IActionResult Index()
        {
            IEnumerable<LinhaReceita> oListaReceitaLInha = RepositoryLinhaReceita.GetAllWithDetails();
            return View(oListaReceitaLInha);
        }


        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Linha> oListaLinha = _repositoryLinha.GetAll();
            IEnumerable<Receita> oListaReceita = _repositoryReceita.GetAll();
            ViewBag.vbLinha = new SelectList(oListaLinha, "Id", "NomeCor");
            ViewBag.vbReceita = new SelectList(oListaReceita, "Id", "Nome");

            LinhaReceitaVM olinhaReceitaVM = new(oListaLinha, oListaReceita);

            return View(olinhaReceitaVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LinhaReceitaVM NovaLinhaReceita)
        {
            if (ModelState.IsValid)
            {
                Linha linha = _repositoryLinha.GetById(NovaLinhaReceita.IdLinha);
                Receita Receita = _repositoryReceita.GetById(NovaLinhaReceita.IdReceita);
                LinhaReceita linha_receita = new()
                {
                    ReceitaId = NovaLinhaReceita.IdLinha,
                    LinhaId = NovaLinhaReceita.IdReceita
                };
                _repository.Insert(linha_receita);
                return RedirectToAction(nameof(Index));
            }

            return View("Index");
        }










    }
}
