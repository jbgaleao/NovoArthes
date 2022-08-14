using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;
using Arthes.DATA.Repositories;
using Arthes.WEB.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arthes.WEB.Controllers
{
    public class LinhaController : Controller
    {

        private readonly IRepositoryBase<Linha> _repository;
        private readonly IRepositoryBase<TipoLinha> _repositoryTipoLinha;
        private readonly IRepositoryBase<Fabricante> _repositoryFabricante;

        public LinhaController(IRepositoryBase<Linha> repository,
                               IRepositoryBase<TipoLinha> repositoryTipoLinha,
                               IRepositoryBase<Fabricante> repositoryFabricante)
        {
            _repository = repository;
            _repositoryTipoLinha = repositoryTipoLinha;
            _repositoryFabricante = repositoryFabricante;
        }

        public IActionResult Index()
        {
            IEnumerable<Linha> oListaLiha = RepositoryLinha.GetAllWithDetails();
            return View(oListaLiha);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<TipoLinha> oListaTipoLinha = _repositoryTipoLinha.GetAll();
            IEnumerable<Fabricante> oListaFabricante = _repositoryFabricante.GetAll();
            ViewBag.TipoLinha = new SelectList(oListaTipoLinha, "Id", "Descricao");
            ViewBag.Fabricante = new SelectList(oListaFabricante, "Id", "Nome");

            LinhaVM oNovaLinha = new(oListaTipoLinha, oListaFabricante);
            return View(oNovaLinha);
        }

        [HttpPost]
        public IActionResult Create(LinhaVM linhaVM)
        {
            if (ModelState.IsValid)
            {
                Linha linha = new()
                {
                    CodLinha = linhaVM.CodLinha,
                    NomeCor = linhaVM.NomeCor,
                    TipoLinhaId = linhaVM.IdTipoLinha,
                    FabricanteId = linhaVM.IdFabricante
                };
                _repository.Insert(linha);
                return RedirectToAction("Index");
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
            Linha linha = RepositoryLinha.GetWithDetails((int)id);
            return View(linha);
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
            Linha linha = RepositoryLinha.GetWithDetails((int)id);
            return View(linha);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Linha linha = _repository.GetById(id);


            IEnumerable<TipoLinha> oListaTipoLinha = _repositoryTipoLinha.GetAll();
            IEnumerable<Fabricante> oListaFabricante = _repositoryFabricante.GetAll();
            ViewBag.TipoLinha = new SelectList(oListaTipoLinha, "Id", "Descricao");
            ViewBag.Fabricante = new SelectList(oListaFabricante, "Id", "Nome");

            LinhaVM oNovaLinha = new(oListaTipoLinha, oListaFabricante);
            oNovaLinha.CodLinha = linha.CodLinha;
            oNovaLinha.NomeCor = linha.NomeCor;
            return View(oNovaLinha);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LinhaVM EditadaLinha)
        {
            if (ModelState.IsValid)
            {
                Linha linha = new()
                {
                    Id = EditadaLinha.Id,
                    CodLinha = EditadaLinha.CodLinha,
                    NomeCor = EditadaLinha.NomeCor,
                    TipoLinhaId = EditadaLinha.IdTipoLinha,
                    FabricanteId = EditadaLinha.IdFabricante
                };
                _repository.Update(linha);
                return RedirectToAction("Index");
            }
            return View("Index");
        }























    }
}
