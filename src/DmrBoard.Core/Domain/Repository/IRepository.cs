using DmrBoard.Core.Domain.Entities;
using DmrBoard.Core.Domain.Specifications;
using System.Collections.Generic;

namespace DmrBoard.Core.Domain.Repository
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
    }
}
