using System.Collections.Generic;
using System.Linq;
using FinChat.Chat.Application.Enums;

namespace FinChat.Chat.Application.Models
{
    public class BasicOutput<TOutput>
    {
        public BasicOutput()
        {
            Messages = new List<OutputNotification>();
        }
        public TOutput Output { get; set; }
        public List<OutputNotification> Messages { get; set; }
        public bool Success => Messages.All(msg => msg.Type != EOutputNotificationType.Error);
    }
}