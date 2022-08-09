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


        public IEnumerable<T> GetAll()
        {
            return  _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int? id)
        {
            return  _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _ = _context.Set<T>().Add(entity);
            _ = _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _ = _context.Set<T>().Update(entity);
            _ = _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            T entity =  GetById(id);
            _ = _context.Set<T>().Remove(entity);
            _ = _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
