using System.Threading.Tasks;
using FinChat.Chat.Application.Models;

namespace FinChat.Chat.Application.Interfaces
{
    public interface IChatService
    {
        Task<BasicOutput<string>> SendMessage(string chatRoomId, string userId, string message);
    }
}