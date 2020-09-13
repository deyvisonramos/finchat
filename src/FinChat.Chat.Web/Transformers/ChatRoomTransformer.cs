using System.Collections.Generic;
using System.Linq;
using FinChat.Chat.Domain.Entities;
using FinChat.Chat.Web.Models;
using FinChat.Chat.Web.Transformers.Interfaces;

namespace FinChat.Chat.Web.Transformers
{
    public class ChatRoomTransformer: ITransformer<ChatRoom, ChatRoomViewModel>
    {
        private readonly ITransformer<ChatMessage, ChatMessageViewModel> _chatMessageTransformer;

        public ChatRoomTransformer(ITransformer<ChatMessage, ChatMessageViewModel> chatMessageTransformer)
        {
            _chatMessageTransformer = chatMessageTransformer;
        }

        public ChatRoomViewModel Transform(ChatRoom chatRoom)
        {
            if (chatRoom == null)
                return null;

            var viewModel = new ChatRoomViewModel
            {
                Id = chatRoom.Id.ToString(),
                Name = chatRoom.Name
            };

            if (!chatRoom.Conversation.Any()) return viewModel;

            var messages = chatRoom.Conversation.Select(_chatMessageTransformer.Transform);
            viewModel.Conversation.AddRange(messages);

            return viewModel;
        }

        public IEnumerable<ChatRoomViewModel> Transform(IEnumerable<ChatRoom> @in)
        {
            return @in.Select(Transform);
        }
    }
}