using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FinChat.Chat.Domain.Entities.Validators;

namespace FinChat.Chat.Domain.Entities
{
    public class ChatRoom: Entity
    {
        protected ChatRoom()
        {
        }

        public ChatRoom(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Conversation = new Collection<ChatMessage>();

            Validate(this, new ChatRoomValidator());
        }

        public string Name { get; set; }
        public ICollection<ChatMessage> Conversation { get; set; }

        public void AddChatMessage(ChatMessage chatMessage)
        {
            Conversation.Add(chatMessage);
        }

        public override string ToString()
        {
            return $"{Name} - {Id}";
        }
    }
}