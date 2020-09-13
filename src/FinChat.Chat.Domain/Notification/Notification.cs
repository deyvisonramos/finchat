namespace FinChat.Chat.Domain.Notification
{
    public class Notification
    {
        public Notification(string message, ENotificationType type, string subject)
        {
            Message = message;
            Type = type;
            Subject = subject;
        }

        public string Message { get; }
        public ENotificationType Type { get; }
        public string Subject { get; }
    }
}