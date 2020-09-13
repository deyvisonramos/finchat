using System.Collections.Generic;
using System.Threading.Tasks;
using FinChat.Chat.Application.Models;
using FinChat.Chat.Domain.Entities;

namespace FinChat.Chat.Application.Interfaces
{
    public interface IChatService
    {
        Task<BasicOutput<IEnumerable<ChatRoom>>> GetChatRooms();
        Task<BasicOutput<ChatRoom>> GetChatRoom(string chatRoomId);
        Task<BasicOutput<IEnumerable<ChatMessage>>> GetRecentChatRoomConversation(string chatRoomId);
        Task<BasicOutput<ChatRoom>> CreateChatRoom(string chatRoomName);
        Task<BasicOutput<string>> SendMessage(
            string chatRoomId,
            string authorId,
            string authorName,
            string message);
    }
}