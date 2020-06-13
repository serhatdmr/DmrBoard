using DmrBoard.Core.Domain.Entities;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Domain.Specifications;
using DmrBoard.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmrBoard.EntityFrameworkCore.Data
{
    public class EfRepository<T, TPrimaryKey> : IRepository<T, TPrimaryKey> where T : Entity<TPrimaryKey>
    {
        protected readonly DmrDbContext _dbContext;

        public EfRepository(DmrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById(TPrimaryKey id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return Get(spec).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> Get(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                .Where(spec.Criteria)
                .AsEnumerable();
        }
        //public IEnumerable<T> Get(ISpecification<T> spec, IPagedResultRequest pagedResultRequest)
        //{
        //    // fetch a Queryable that includes all expression-based includes
        //    var queryableResultWithIncludes = spec.Includes
        //        .Aggregate(_dbContext.Set<T>().AsQueryable(),
        //            (current, include) => current.Include(include));

        //    // modify the IQueryable to include any string-based include statements
        //    var secondaryResult = spec.IncludeStrings
        //        .Aggregate(queryableResultWithIncludes,
        //            (current, include) => current.Include(include));

        //    // return the result of the query using the specification's criteria expression
        //    return secondaryResult
        //        .
        //        .Where(spec.Criteria)
        //        .AsEnumerable();
        //}
        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TPrimaryKey id)
        {
            bool isSoftDelete = false;
            var entry = GetById(id);
            var entries = _dbContext.ChangeTracker.Entries();
            foreach (var changedEntity in entries)
            {
                if (changedEntity.Entity is ISoftDelete softDeleteEntity)
                {
                    _dbContext.Entry(entry).State = EntityState.Modified;
                    softDeleteEntity.IsDeleted = true;
                    isSoftDelete = true;
                }
            }

            if (!isSoftDelete)
                HardDelete(id);

        }
        public void HardDelete(TPrimaryKey id)
        {
            _dbContext.Set<T>().Remove(GetById(id));
        }

        public async Task<T> GetByIdAsync(TPrimaryKey id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
