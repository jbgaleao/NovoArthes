
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

namespace Arthes.DATA.Repositories
{
    public class RepositoryLinhaReceita : RepositoryBase<LinhaReceita>, IRepositoryLinhaReceita
    {
        public RepositoryLinhaReceita(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {

        }
    }
}
