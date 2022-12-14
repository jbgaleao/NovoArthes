#nullable disable
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Repositories
{
    public class RepositoryReceita : RepositoryBase<Receita>, IRepositoryReceita
    {
        private static readonly ArthesContext context = new();

        public RepositoryReceita(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {
        }

        public static List<Receita> GetAllWithDetails()
        {
            return context.Receita
                  .Include(a => a.IdRevistaNavigation)
                  .AsNoTracking()
                  .ToList<Receita>();
        }
        public static List<Receita> GetAllWithDetails(int id)
        {
            return context.Receita
                  .Include(a => a.IdRevistaNavigation)
                  .AsNoTracking()
                  .Where(a => a.Id == id)
                  .ToList<Receita>();
        }

        public static List<Receita> ListaReceitasPorRevistaId(int id)
        {
            return context.Receita
                  .Include(a => a.IdRevistaNavigation)
                  .AsNoTracking()
                  .Where(a => a.IdRevistaNavigation.Id == id)
                  .ToList<Receita>();
        }

        public static Receita GetWithDetails(int id)
        {
            return context.Receita
                  .Include(a => a.IdRevistaNavigation)
                  .AsNoTracking()
                  .Where(a => a.Id == id)
                  .FirstOrDefault<Receita>();
        }

    }
}
