
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

namespace Arthes.DATA.Repositories
{
    public class RepositoryTipoLinha : RepositoryBase<TipoLinha>, IRepositoryTipoLinha
    {
        public RepositoryTipoLinha(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {

        }
    }
}
