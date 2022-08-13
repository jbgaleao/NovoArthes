#nullable disable

using Arthes.DATA.Models;
using Arthes.DATA.Models.Enum;

namespace Arthes.WEB.Models
{
    public class ReceitaVM
    {
        public ReceitaVM()
        {

        }
       
        public ReceitaVM(IEnumerable<Revista> listaRevista)
        {
            this.listaRevista = listaRevista;
        }


        public int Id { get; set; }
        public string Nome { get; set; }
        public int Altura { get; set; }
        public NivelDificuldade NivelDificuldade { get; set; }
        public int IdRevista { get; set; }
        public Revista Revista { get; set; }

        public IEnumerable<Revista> listaRevista { get; set; }
    }
}
