using System.Threading.Tasks;
using FinChat.Chat.Application.Interfaces;
using FinChat.Chat.Domain.Entities;
using FinChat.Chat.WebSocket.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace FinChat.Chat.WebSocket
{
    public class SignalRWebSocket: IWebSocketService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public SignalRWebSocket(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task<bool> CreateRoom(string chatRoomId)
        {
            throw new System.NotImplementedException();
        }

        public async Task SendMessage(string chatRoomId, ChatMessage chatMessage)
        {
            await _hubContext.Clients.Group(chatRoomId).SendAsync("ReceiveMessage", chatMessage.Author.Name, chatMessage.FormattedContent).ConfigureAwait(true);
        }

        public async Task SendCommand(string chatRoomId, string command)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveCommand", chatRoomId, command).ConfigureAwait(true);
        }
    }
}