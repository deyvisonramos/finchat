using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinChat.Chat.Domain.Entities;

namespace FinChat.Chat.Domain.Interfaces.Repositories
{
    public interface IChatRoomRepository
    {
        IEnumerable<ChatRoom> GetAll();
        Task<ChatRoom> GetChatRoomById(Guid chatRoomId, bool includeConversation);
        IEnumerable<ChatMessage> GetChatRoomConversation(Guid chatRoomId, int messagesAmount);
        Task Create(ChatRoom chatRoom);
        void Update(ChatRoom chatRoom);
    }
}