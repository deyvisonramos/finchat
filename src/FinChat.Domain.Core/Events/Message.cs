namespace FinChat.Domain.Core.Events
{
    public class Message
    {
        protected Message()
        {
            Type = GetType().Name;
        }

        public string Type { get; protected set; }
    }
}