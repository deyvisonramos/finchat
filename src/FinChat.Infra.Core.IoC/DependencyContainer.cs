using FinChat.Domain.Core.Bus;
using FinChat.Infra.Core.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinChat.Infra.Core.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddCoreEventBus(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var configuration = sp.GetService<IConfiguration>();
                return new RabbitMQBus(scopeFactory, configuration);
            });

            return services;
        }
    }
}