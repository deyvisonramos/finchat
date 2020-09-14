using System.Collections.Generic;
using System.Threading.Tasks;
using FinChat.Chat.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace FinChat.Chat.WebSocket.Hubs
{
    public class ChatHub : Hub
    {
        private readonly Dictionary<string, string> _connections = new Dictionary<string, string>();

        public async Task JoinRoom(string userId, string chatRoomId)
        {
            if(!_connections.ContainsKey(userId))
                _connections.Add(userId, Context.ConnectionId);

            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId).ConfigureAwait(false);
        }

        public Task LeaveRoom(string chatRoomId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId);
        }
    }
}