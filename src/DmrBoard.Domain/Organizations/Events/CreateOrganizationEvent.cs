using DmrBoard.Core.Events;
using System;

namespace DmrBoard.Domain.Organizations
{
    public class CreateOrganizationEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CreateOrganizationEvent(Guid id,string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }
    }
}
