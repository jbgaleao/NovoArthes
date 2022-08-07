#nullable disable
using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Repositories
{
    public class RepositoryRevista : IRepositoryRevista, IDisposable
    {
        protected readonly ArthesContext _context;
        public RepositoryRevista(ArthesContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Revista>> GetAll()
        {
            return await _context.Set<Revista>().AsNoTracking().ToListAsync();
        }

        public async Task<Revista> GetById(int? id)
        {
            return await _context.Set<Revista>().FindAsync(id);
        }

        public async Task Insert(Revista entity)
        {
            _ = await _context.Set<Revista>().AddAsync(entity);
            _ = await _context.SaveChangesAsync();
        }

        public async Task Update(Revista entity)
        {
            _ = _context.Set<Revista>().Update(entity);
            _ = await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            Revista entity = await GetById(id);
            _ = _context.Set<Revista>().Remove(entity);
            _ = await _context.SaveChangesAsync();
        }

        public void Dispose()
            {
                _context.Dispose();
            }
    }
}
