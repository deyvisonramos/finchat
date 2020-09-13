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
            Content = content;
            Author = author;

            Validate(this, new ChatMessageValidator());
        }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; }
        public ChatMessageAuthor Author { get; set; }
        public bool IsCommand => Content[0] == '/';
        public string FormattedContent => $"{Author.Name} says {Content} at {PostedAt:dd/MM/yyyy hh:mm}"; 
        public override string ToString()
        {
            return FormattedContent;
        }
    }
}