using System.Collections.Generic;
using System.Threading.Tasks;
using FinChat.Chat.Domain.Entities;

namespace FinChat.Chat.Domain.Interfaces.Repositories
{
    public interface IChatRoomRepository
    {
        Task<IEnumerable<ChatRoom>> GetAll();
        Task<ChatRoom> GetChatRoomById(string chatRoomId, bool includeConversation);
        Task<IEnumerable<ChatMessage>> GetChatRoomConversation(string chatRoomId, int messages);
        Task Create(ChatRoom chatRoom);
        Task Update(ChatRoom chatRoom);
    }
}