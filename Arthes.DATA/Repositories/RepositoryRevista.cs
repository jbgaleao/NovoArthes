
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

namespace Arthes.DATA.Repositories
{
    public class RepositoryRevista : RepositoryBase<Revista>, IRepositoryRevista
    {
        public RepositoryRevista(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {

        }
    }
}
