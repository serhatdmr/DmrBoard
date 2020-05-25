using DmrBoard.Core.Bus;
using DmrBoard.Core.Commands;
using DmrBoard.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace DmrBoard.Domain.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;
        public InMemoryBus(IMediator mediator, IEventStore eventStore)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
