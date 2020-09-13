using FinChat.Chat.Application.Interfaces;
using FinChat.Chat.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinChat.Chat.IoC
{
    public static class ChatDependencyInjection
    {
        public static void RegisterChatServices(this IServiceCollection services)
        {
            services.AddTransient<IChatService, ChatService>();
        }
    }
}