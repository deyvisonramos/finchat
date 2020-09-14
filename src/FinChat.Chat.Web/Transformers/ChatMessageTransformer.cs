using System.Collections.Generic;
using System.Linq;
using FinChat.Chat.Domain.Entities;
using FinChat.Chat.Web.Models;
using FinChat.Chat.Web.Transformers.Interfaces;

namespace FinChat.Chat.Web.Transformers
{
    public class ChatMessageTransformer: ITransformer<ChatMessage, ChatMessageViewModel>
    {
        public ChatMessageViewModel Transform(ChatMessage chatMessage)
        {
            if (chatMessage == null)
                return null;

            var viewModel = new ChatMessageViewModel
            {
                AuthorId = chatMessage.Author.Name,
                AuthorName = chatMessage.Author.Name,
                Message = chatMessage.FormattedContent
            };

            return viewModel;
        }

        public IEnumerable<ChatMessageViewModel> Transform(IEnumerable<ChatMessage> @in)
        {
            return @in.Select(Transform);
        }
    }
}