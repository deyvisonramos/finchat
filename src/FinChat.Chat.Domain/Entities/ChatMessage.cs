using System;
using FinChat.Chat.Domain.ValueObjects;

namespace FinChat.Chat.Domain.Entities
{
    public class ChatMessage
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; }
        public ChatMessageAuthor Author { get; set; }   
    }
}