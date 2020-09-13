using FinChat.Chat.Domain.Entities;
using FinChat.Chat.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinChat.Chat.Data.Repositories
{
    public class ChatRoomRepository: IChatRoomRepository
    {
        public Task Create(ChatRoom chatRoom)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ChatRoom>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ChatRoom> GetChatRoomById(string chatRoomId, bool includeConversation)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ChatMessage>> GetChatRoomConversation(string chatRoomId, int messages)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(ChatRoom chatRoom)
        {
            throw new System.NotImplementedException();
        }
    }
}
