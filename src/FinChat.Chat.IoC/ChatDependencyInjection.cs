using FinChat.Chat.Application.Interfaces;
using FinChat.Chat.Application.Services;
using FinChat.Chat.Domain.Interfaces.Repositories;
using FinChat.Chat.Data.Repositories;
using FinChat.Chat.Data.Transactions;
using FinChat.Chat.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace FinChat.Chat.IoC
{
    public static class ChatDependencyInjection
    {
        public static void RegisterChatServices(this IServiceCollection services)
        {
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IWebSocketService, SignalRWebSocket>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IChatRoomRepository, ChatRoomRepository>();
        }
    }
}