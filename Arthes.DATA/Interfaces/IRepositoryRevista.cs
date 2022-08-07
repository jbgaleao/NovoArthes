
using Arthes.DATA.Models;

namespace Arthes.DATA.Interfaces
{
    public interface IRepositoryRevista 
    {
        Task<IEnumerable<Revista>> GetAll();
        Task<Revista> GetById(int? id);
        Task Insert(Revista revista);
        Task Update(Revista revista);
        Task Delete(int? id);
    }
}
