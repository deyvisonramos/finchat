using FinChat.Domain.Core.Bus;
using FinChat.Infra.Core.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinChat.Infra.Core.IoC
{
    public static class DependencyContainer
    {
        public static void AddCoreEventBus(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(
                    sp.GetService<IMediator>(),
                    scopeFactory
                );
            });
        }
    }
}