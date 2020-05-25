using DmrBoard.Core.Domain.Entities;
using DmrBoard.Core.Domain.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DmrBoard.Core.Domain.Interfaces
{
    public interface IRepository<T, TPrimaryKey> where T : Entity<TPrimaryKey>
    {

        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> Get(ISpecification<T> spec);


        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);

        int SaveChanges();
    }
}
