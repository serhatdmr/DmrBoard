using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DmrBoard.Core.Domain.Repository
{
    public interface IUnitofWork : IDisposable
    {
        DbContext Context { get; }
        void Commit();
        Task CommitAsync();
    }

    public class UnitOfWork : IUnitofWork
    {
        public DbContext Context { get; }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
