using DmrBoard.Core.Events;
using System;

namespace DmrBoard.Core.Domain.Interfaces
{
    public interface IEventStoreRepository : IDisposable
    {
        void Save(StoredEvent storedEvent);
    }
}
