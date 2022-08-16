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
            IEnumerable<Linha> oListaTipoLinha = _repositoryLinha.GetAll();
            IEnumerable<Receita> oListaFabricante = _repositoryReceita.GetAll();
            //ViewBag.TipoLinha = new SelectList(oListaTipoLinha, "Id", "Descricao");
            //ViewBag.Fabricante = new SelectList(oListaFabricante, "Id", "Nome");

            //LinhaVM oNovaLinha = new(oListaTipoLinha, oListaFabricante);
            return View();
        }














    }
}
