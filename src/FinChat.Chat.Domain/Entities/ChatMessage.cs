using System;
using FinChat.Chat.Domain.Entities.Validators;
using FinChat.Chat.Domain.ValueObjects;

namespace FinChat.Chat.Domain.Entities
{
    public class ChatMessage: Entity
    {
        protected ChatMessage()
        {

        }

        public ChatMessage(string content, ChatMessageAuthor author)
        {
            Id = Guid.NewGuid();
            PostedAt = DateTime.Now;
            Content = content;
            Author = author;

            Validate(this, new ChatMessageValidator());
        }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; }
        public ChatMessageAuthor Author { get; set; }
        public ChatRoom ChatRoom { get; set; }
        public bool IsCommand => Content[0] == '/';
        public string FormattedContent => $"{Author.Name} says {Content} at {PostedAt:f}"; 
        public override string ToString()
        {
            return FormattedContent;
        }
    }
}