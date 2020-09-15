namespace FinChat.Domain.Core
{
    public class MessageQueueConnectionSettings
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public bool PublisherConfirms { get; set; }
        public int TimeOut { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}