using System;

namespace FinChat.Chat.Domain.Entities
{
    public class ChatRoom
    {
        protected ChatRoom()
        {

        }

        public ChatRoom(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Id}";
        }
    }
}