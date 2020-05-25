using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Events;

namespace DmrBoard.EntityFrameworkCore.Data.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly DmrDbContext _context;

        public EventStoreRepository(DmrDbContext context)
        {
            _context = context;
        }
        public void Save(StoredEvent storedEvent)
        {
            _context.StoredEvents.Add(storedEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
