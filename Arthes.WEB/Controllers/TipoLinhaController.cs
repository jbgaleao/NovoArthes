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
    }
}
