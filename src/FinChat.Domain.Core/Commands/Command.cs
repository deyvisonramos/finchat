using System;
using FinChat.Domain.Core.Events;

namespace FinChat.Domain.Core.Commands
{
    public class Command : Message
    {
        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp { get; protected set; }
    }
}