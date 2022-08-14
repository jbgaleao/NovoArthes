#nullable disable
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Repositories
{
    public class RepositoryLinhaReceita : RepositoryBase<LinhaReceita>, IRepositoryLinhaReceita
    {

        private static readonly ArthesContext context = new();

        public RepositoryLinhaReceita(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {

        }

        public static LinhaReceita GetWithDetails(int id)
        {
            return context.LinhaReceita
                  .Include(a => a.ReceitaId)
                  .Include(b => b.LinhaId)
                  .AsNoTracking()
                  .Where(c => c.Id == id)
                  .FirstOrDefault<LinhaReceita>();
        }


        public static List<LinhaReceita> GetAllWithDetails()
        {
            return context.LinhaReceita
                  .Include(a => a.Linha)
                  .Include(b => b.Receita)
                  .AsNoTracking()
                  .ToList<LinhaReceita>();
        }
    }
}
