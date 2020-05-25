using DmrBoard.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Core.Events
{
    public class StoredEvent : Event
    {
        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        // EF Constructor
        protected StoredEvent() { }


        public string Data { get; private set; }

        public string User { get; private set; }

        public Guid Id { get; private set; }
    }
}
