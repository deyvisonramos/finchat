using System;
using FinChat.Domain.Core.Bus;
using FinChat.Infra.Core.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinChat.ChatBots.StockQuotation
{
    public class Setup
    {
        private IServiceProvider _serviceProvider;

        public static Setup Build()
        {
            return new Setup();
        }

        public IServiceProvider ConfigureServices()
        {
            if (_serviceProvider != null)
                return _serviceProvider;

            IConfiguration configuration = BuildConfiguration();
            _serviceProvider = 
                new ServiceCollection()
                .AddCoreEventBus()
                .AddSingleton<IConfiguration>(configuration)
                .BuildServiceProvider();

            return _serviceProvider;
        }

        private IConfiguration BuildConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable("ENVIRONMENT");
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}