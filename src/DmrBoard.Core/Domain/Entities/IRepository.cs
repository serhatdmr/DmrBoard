using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DmrBoard.Core.Domain.Entities
{
    public interface IRepository<T, TPrimaryKey> where T : Entity<TPrimaryKey>
    {

        T GetById(int id);
        IEnumerable<T> GetAllList(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAllList();
        IQueryable<T> GetAll();
        T FirstOrDefault(TPrimaryKey id);

        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);



        //T GetSingleBySpec(ISpecification<T> spec);
        //IEnumerable<T> Get(ISpecification<T> spec);
    }
}
