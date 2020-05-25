using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DmrBoard.Core.Domain.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        bool Commit();
    }
}
