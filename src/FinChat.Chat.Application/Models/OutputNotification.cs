using FinChat.Chat.Application.Enums;

namespace FinChat.Chat.Application.Models
{
    public class OutputNotification
    {
        public OutputNotification(string message, EOutputNotificationType type, string subject)
        {
            Message = message;
            Type = type;
            Subject = subject;
        }
        
        public string Message { get; }
        public EOutputNotificationType Type { get; }
        public string Subject { get; }
    }
}