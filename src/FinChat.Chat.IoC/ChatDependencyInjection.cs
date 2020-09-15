using FinChat.Chat.Application.EventHandlers;
using FinChat.Chat.Application.Events;
using FinChat.Chat.Application.Interfaces;
using FinChat.Chat.Application.Services;
using FinChat.Chat.Domain.Interfaces.Repositories;
using FinChat.Chat.Data.Repositories;
using FinChat.Chat.Data.Transactions;
using FinChat.Chat.WebSocket;
using FinChat.Domain.Core.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace FinChat.Chat.IoC
{
    public static class ChatDependencyInjection
    {
        public static void RegisterChatServices(this IServiceCollection services)
        {
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IWebSocketService, SignalRWebSocket>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IChatRoomRepository, ChatRoomRepository>();
        }

        public static void RegisterChatEventHandlers(this IServiceCollection services)
        {
            services.AddTransient<CommandProcessedEventHandler>();
            services.AddTransient<IEventHandler<CommandProcessedEvent>, CommandProcessedEventHandler>();
        }
    }
}