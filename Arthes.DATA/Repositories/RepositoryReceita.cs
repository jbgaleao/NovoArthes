#nullable disable
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Repositories
{
    public class RepositoryReceita : RepositoryBase<Receita>, IRepositoryReceita
    {

        public RepositoryReceita(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {
        }

        public static List<Receita> GetAllWithDetails()
        {
            using (ArthesContext context = new ArthesContext())
            {
                return context.Receita
                      .Include(a => a.IdRevistaNavigation)
                      .ToList<Receita>();
            }
        }

    }
}
