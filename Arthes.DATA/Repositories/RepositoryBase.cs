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

        public RepositoryBase(bool saveChanges = true)
        {
            _SaveChanges = saveChanges;
            _context = new ArthesContext();
        }


        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(params object[] variavel)
        {
            return _context.Set<T>().Find(variavel);
        }


        public T Insert(T entity)
        {
            _ = _context.Set<T>().Add(entity);
            if (_SaveChanges)
                _ = _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            if (_SaveChanges)
                _ = _context.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _ = _context.Set<T>().Remove(entity);
            if (_SaveChanges)
                _ = _context.SaveChanges();
        }

        public void Delete(params object[] variavel)
        {
            T entity = GetById(variavel);
            Delete(entity);
        }

        public void SaveChanges()
        {
            _ = _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
