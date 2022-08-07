
using Arthes.DATA.Models;

namespace Arthes.DATA.Interfaces
{
    public interface IRepositoryReceita 
    {
        Task<IEnumerable<Receita>> GetAll();
        Task<IEnumerable<Receita>> GetAllWithRevista();
        Task<Receita> GetById(int? id);
        Task Insert(Receita receita);
        Task Update(Receita receita);
        Task Delete(int? id);
    }
}
