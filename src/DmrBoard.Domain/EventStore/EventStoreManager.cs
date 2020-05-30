using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Events;
using DmrBoard.Core.Interfaces;
using System.Text.Json;

namespace DmrBoard.Domain.EventStore
{
    public class EventStoreManager : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly ICurrentUserService _userSession;
        public EventStoreManager(IEventStoreRepository eventStoreRepository,
            ICurrentUserService userSession)
        {
            _eventStoreRepository = eventStoreRepository;
            _userSession = userSession;
        }
        public void Save<T>(T theEvent) where T : Event
        {
            var data = JsonSerializer.Serialize(theEvent);
            var eventStore = new StoredEvent(theEvent, data, _userSession.Name);
            _eventStoreRepository.Save(eventStore);
        }
    }
}
