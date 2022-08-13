
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

namespace Arthes.DATA.Repositories
{
    public class RepositoryFabricante : RepositoryBase<Fabricante>, IRepositoryFabricante
    {
        public RepositoryFabricante(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {

        }
    }
}
