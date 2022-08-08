
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

namespace Arthes.DATA.Repositories
{
    public class RepositoryReceita : RepositoryBase<NovaReceitaViewModel>, IRepositoryReceita
    {
        public RepositoryReceita(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {

        }
    }
}
