#nullable disable



using Arthes.DATA.Data;
using Arthes.DATA.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        protected readonly ArthesContext _context;
        public bool _SaveChanges = true;

        public RepositoryBase(ArthesContext context, bool saveChanges = true)
        {
            _SaveChanges = saveChanges;
            _context = context;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            T entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
