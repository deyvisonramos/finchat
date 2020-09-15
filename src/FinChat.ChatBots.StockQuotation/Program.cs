using System;
using System.Threading.Tasks;
using FinChat.ChatBots.StockQuotation.Events;
using FinChat.ChatBots.StockQuotation.Tools;
using FinChat.Domain.Core.Bus;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinChat.ChatBots.StockQuotation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = Setup.Build().ConfigureServices();
            var eventBus = serviceProvider.GetService<IEventBus>();
            var configuration = serviceProvider.GetService<IConfiguration>();

            var connection = new HubConnectionBuilder()
                .WithUrl(configuration.GetSection("chatHubUrl").Value)
                .WithAutomaticReconnect()
                .Build();


            connection.On<string, string>("ReceiveCommand", (chatRoom, command) =>
            {
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
                connection.StartAsync().Wait();
                Console.WriteLine("the quotation bot has been started.");
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            Console.WriteLine("press any key to stop the bot");
            Console.ReadKey();
        }
    }
}
