#nullable disable

namespace Arthes.DATA.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
        T GetById(params object[] variavel);

        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(params object[] variavel);
        void SaveChanges();
    }
}
