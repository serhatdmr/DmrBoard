using DmrBoard.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace DmrBoard.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
