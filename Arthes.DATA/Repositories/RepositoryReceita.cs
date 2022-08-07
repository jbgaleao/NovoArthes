#nullable disable
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Repositories
{
    public class RepositoryReceita : IRepositoryReceita, IDisposable
    {
        protected readonly ArthesContext _context;
        public RepositoryReceita(ArthesContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Receita>> GetAll()
        {
            return await _context.Set<Receita>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Receita>> GetAllWithRevista()
        {
            return await _context.Set<Receita>()
                .Include(c => c.IdRevistaNavigation)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Receita> GetById(int? id)
        {
            return await _context.Set<Receita>().FindAsync(id);
        }

        public async Task Insert(Receita entity)
        {
            _ = await _context.Set<Receita>().AddAsync(entity);
            _ = await _context.SaveChangesAsync();
        }

        public async Task Update(Receita entity)
        {
            _ = _context.Set<Receita>().Update(entity);
            _ = await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            Receita entity = await GetById(id);
            _ = _context.Set<Receita>().Remove(entity);
            _ = await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
