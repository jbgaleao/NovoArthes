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



















    }
}
