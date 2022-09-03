#nullable disable
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Repositories
{
    public class RepositoryFabricante : RepositoryBase<Fabricante>, IRepositoryFabricante
    {
        private static readonly ArthesContext context = new();

        public RepositoryFabricante(ArthesContext context, bool SaveChanges = true) : base(context, SaveChanges)
        {

        }

        public static bool TemLinhaAssociada(int id)
        {
            List<Fabricante> qry = context.Fabricante
                            .Include(a => a.Linha)
                            .Where(a => a.Id == id)
                            .AsNoTracking()
                            .ToList<Fabricante>();
            foreach (ICollection<Linha> item in (qry.Select(a => a.Linha)))
            {
                if (item.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
