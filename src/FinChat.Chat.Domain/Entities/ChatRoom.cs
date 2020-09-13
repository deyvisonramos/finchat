using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FinChat.Chat.Domain.Entities
{
    public class ChatRoom
    {
        protected ChatRoom()
        {
            Conversation = new Collection<ChatMessage>();
        }

        public ChatRoom(string name): this()
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<ChatMessage> Conversation { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Id}";
        }
    }
}