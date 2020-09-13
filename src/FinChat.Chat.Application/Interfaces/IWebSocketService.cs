using System.Threading.Tasks;
using FinChat.Chat.Domain.ValueObjects;

namespace FinChat.Chat.Application.Interfaces
{
    public interface IWebSocketService
    {
        Task<bool> CreateRoom(string chatRoomId);
        Task SendMessage(string chatRoomId, string authorId, string authorName, string message);
    }
}