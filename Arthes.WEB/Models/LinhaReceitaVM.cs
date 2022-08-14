#nullable disable
using Arthes.DATA.Models;

namespace Arthes.WEB.Models
{
    public class LinhaReceitaVM
    {
        public LinhaReceitaVM()
        {

        }

        public int Id { get; set; }
        
        public int IdLinha { get; set; }
        public virtual Linha linha { get; set; }
        
        public int IdReceita { get; set; }
        public virtual Receita receita { get; set; }

    }
}
