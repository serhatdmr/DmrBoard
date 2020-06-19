using DmrBoard.Core.Domain.Entities;
using DmrBoard.Core.Domain.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmrBoard.Core.Domain.Interfaces
{
    public interface IRepository<T, TPrimaryKey> where T : Entity<TPrimaryKey>
    {
        IQueryable<T> GetAll();
        T GetById(TPrimaryKey id);
        IEnumerable<T> GetAllList();
        T Add(T entity);
        void Update(T entity);
        void Delete(TPrimaryKey id);
        void HardDelete(TPrimaryKey id);
        T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> Get(ISpecification<T> spec);


        Task<T> GetByIdAsync(TPrimaryKey id);
        Task<T> AddAsync(T entity);

        int SaveChanges();
    }
}
