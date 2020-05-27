using DmrBoard.Core.Domain.Interfaces;

namespace DmrBoard.EntityFrameworkCore.Data
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly DmrDbContext _dbContext; 

        public UnitOfWork(DmrDbContext dbContext)
        {
            _dbContext = dbContext; 
        }


        public bool Commit()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
