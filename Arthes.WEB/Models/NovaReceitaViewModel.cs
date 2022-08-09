#nullable disable

using Arthes.DATA.Models;
using Arthes.DATA.Models.Enum;

namespace Arthes.WEB.Models
{
    public class NovaReceitaViewModel
    {
        public NovaReceitaViewModel(IEnumerable<Revista> listaRevista)
        {
            this.listaRevista = listaRevista;
        }

        public NovaReceitaViewModel()
        {

        }

        public string Nome { get; set; }
        public int Altura { get; set; }
        public NivelDificuldade NivelDificuldade { get; set; }
        public int IdRevista { get; set; }
        public Revista Revista { get; set; }

        public IEnumerable<Revista> listaRevista { get; set; }
    }
}
