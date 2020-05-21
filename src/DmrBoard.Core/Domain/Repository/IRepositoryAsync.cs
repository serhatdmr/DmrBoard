using DmrBoard.Core.Domain.Entities;
using System.Threading.Tasks;

namespace DmrBoard.Core.Domain.Repository
{
    public interface IRepositoryAsync<T, TPrimaryKey> where T : Entity<TPrimaryKey>
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
    }
}
