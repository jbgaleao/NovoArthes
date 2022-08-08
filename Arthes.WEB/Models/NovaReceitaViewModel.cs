using Arthes.DATA.Models;
using Arthes.DATA.Models.Enum;

namespace Arthes.WEB.Models
{
    public class NovaReceitaViewModel
    {
        public string Nome { get; set; } = null!;
        public int Altura { get; set; }
        public NivelDificuldade NivelDificuldade { get; set; }
        public int IdRevista { get; set; }


        public List<Revista> Revista { get; set; } = null!;

    }
}
