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
        private readonly IRepositoryBase<Linha> _repositoryLinhae;

        public IActionResult Index()
        {
            IEnumerable<LinhaReceita> oListaReceitaLInha = RepositoryLinhaReceita.GetAllWithDetails();
            return View(oListaReceitaLInha);
        }


        [HttpGet]
        public IActionResult Create()
        {
            //IEnumerable<TipoLinha> oListaTipoLinha = _repositoryTipoLinha.GetAll();
            //IEnumerable<Fabricante> oListaFabricante = _repositoryFabricante.GetAll();
            //ViewBag.TipoLinha = new SelectList(oListaTipoLinha, "Id", "Descricao");
            //ViewBag.Fabricante = new SelectList(oListaFabricante, "Id", "Nome");

            //LinhaVM oNovaLinha = new(oListaTipoLinha, oListaFabricante);
            return View();
        }














    }
}
