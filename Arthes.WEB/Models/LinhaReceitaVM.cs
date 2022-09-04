#nullable disable
using Arthes.DATA.Models;

namespace Arthes.WEB.Models
{
    public class LinhaReceitaVM
    {
        public LinhaReceitaVM()
        {

        }
        public LinhaReceitaVM(IEnumerable<Linha> _listaLinha, IEnumerable<Receita> _listaReceita)
        {
            ListaReceita = _listaReceita;
            ListaLinha = _listaLinha;
        }


        public int Id { get; set; }

        public int IdLinha { get; set; }
        public virtual Linha linha { get; set; }
        public IEnumerable<Linha> ListaLinha { get; set; }

        public int IdReceita { get; set; }
        public virtual Receita receita { get; set; }
        public IEnumerable<Receita> ListaReceita { get; set; }

        public int? QtdNovelo { get; set; }

    }
}
