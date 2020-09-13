using System.Collections.Generic;
using System.Linq;
using FinChat.Chat.Domain.Notification;

namespace FinChat.Chat.Application.Models
{
    public class BasicOutput<TOutput>: NotificationContext
    {
        public BasicOutput()
        {
        }

        public TOutput Output { get; private set;}
        public bool Success => !Invalid;

        public void SetOutput(TOutput output)
        {
            Output = output;
        }
    }
}