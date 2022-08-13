#nullable disable
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Repositories
{
    public class RepositoryLinha : RepositoryBase<Linha>, IRepositoryLinha
    {

        private static readonly ArthesContext context = new();

        public RepositoryLinha(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {

        }

        public static Linha GetWithDetails(int id)
        {
            return context.Linha
                  .Include(a => a.TipoLinha)
                  .Include(b => b.Fabricante)
                  .AsNoTracking()
                  .Where(c => c.Id == id)
                  .FirstOrDefault<Linha>();
        }


        public static List<Linha> GetAllWithDetails()
        {
            return context.Linha
                  .Include(a => a.TipoLinha)
                  .Include(b => b.Fabricante)
                  .AsNoTracking()
                  .ToList<Linha>();
        }
    }
}
