#nullable disable
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Repositories
{
    public class RepositoryLinhaReceita : IRepositoryLinhaReceita, IDisposable
    {
        protected readonly ArthesContext _context;
        public RepositoryLinhaReceita(ArthesContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<LinhaReceita>> GetAll()
        {
            return await _context.Set<LinhaReceita>().AsNoTracking().ToListAsync();
        }

        public async Task<LinhaReceita> GetById(int? id)
        {
            return await _context.Set<LinhaReceita>().FindAsync(id);
        }

        public async Task Insert(LinhaReceita entity)
        {
            _ = await _context.Set<LinhaReceita>().AddAsync(entity);
            _ = await _context.SaveChangesAsync();
        }

        public async Task Update(LinhaReceita entity)
        {
            _ = _context.Set<LinhaReceita>().Update(entity);
            _ = await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            LinhaReceita entity = await GetById(id);
            _ = _context.Set<LinhaReceita>().Remove(entity);
            _ = await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
