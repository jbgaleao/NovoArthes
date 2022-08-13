#nullable disable
using Arthes.DATA.Models;

namespace Arthes.WEB.Models
{
    public class LinhaVM
    {
        public LinhaVM()
        {

        }
        
        public LinhaVM(IEnumerable<TipoLinha> listaTipoLinha, IEnumerable<Fabricante> listaFabricante) 
        { 
            this.listaTipoLinha = listaTipoLinha;
            this.listaFabricante = listaFabricante; 
        }


        public int Id { get; set; }

        public string CodLinha { get; set; }
        public string NomeCor { get; set; }
        
        public int IdTipoLinha { get; set; }
        public TipoLinha TipoLinha { get; set; }
        
        public int IdFabricante { get; set; }
        public Fabricante Fabricante { get; set; }


        public IEnumerable<TipoLinha> listaTipoLinha { get; set; }
        public IEnumerable<Fabricante> listaFabricante { get; set; }
    }
}
