
using Arthes.DATA.Models;

namespace Arthes.DATA.Interfaces
{
    public interface IRepositoryLinhaReceita
    {
        Task<IEnumerable<LinhaReceita>> GetAll();
        Task<LinhaReceita> GetById(int? id);
        Task Insert(LinhaReceita linhaReceita);
        Task Update(LinhaReceita linhaReceita);
        Task Delete(int? id);
    }
}
