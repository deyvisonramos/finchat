using System;
using System.Threading;
using System.Threading.Tasks;
using FinChat.ChatBots.StockQuotation.Events;
using FinChat.ChatBots.StockQuotation.Tools;
using FinChat.Domain.Core.Bus;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinChat.ChatBots.StockQuotation
{
    internal class Program
    {
        private static readonly AutoResetEvent WaitHandle = new AutoResetEvent(false);
        private static async Task Main(string[] args)
        {
            var serviceProvider = Setup.Build().ConfigureServices();
            var eventBus = serviceProvider.GetService<IEventBus>();
            var configuration = serviceProvider.GetService<IConfiguration>();

            var connection = new HubConnectionBuilder()
                .WithUrl(configuration.GetSection("chatHubUrl").Value)
                .WithAutomaticReconnect()
                .ConfigureLogging(logging =>
                {
                    logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Information);
                    logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Information);
                    logging.AddConsole();

                })
                .Build();


            connection.On<string, string>("ReceiveCommand", (chatRoom, command) =>
            {
                Console.WriteLine($"command '{command}' received from chatroom '{chatRoom}'");
                var bot = new StockQuotationBot("stock-quotation-bot");
                string contentOutput;

                if (!TextCommandHelper.IsCommand(command))
                    contentOutput = "%The correct command pattern is '/command=value'.";
                else if (!TextCommandHelper.IsCommandAvailable(command))
                    contentOutput =
                        $"%Command not recognized, the available ones are: {TextCommandHelper.GetAvailableCommandsList()}";
                else
                {
                    var stockCode = TextCommandHelper.GetCommandValue(command);
                    contentOutput = bot.Execute(stockCode);
                }

                var commandProcessedEvent = new CommandProcessedEvent(contentOutput, chatRoom, bot.Id, bot.Name);
                eventBus.Publish(commandProcessedEvent);
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Application started. Press Ctrl+C to shut to stop the bot");
            Console.CancelKeyPress += (o, e) =>
            {
                WaitHandle.Set();
            };
            WaitHandle.WaitOne();
        }
    }
}
