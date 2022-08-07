
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


 



        public Task<Include<T>> GetAllWithRevista()
        {

        }
    }
}
