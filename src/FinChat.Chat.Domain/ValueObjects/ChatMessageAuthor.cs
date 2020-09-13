namespace FinChat.Chat.Domain.ValueObjects
{
    public class ChatMessageAuthor
    {
        protected ChatMessageAuthor()
        {

        }
        public ChatMessageAuthor(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}