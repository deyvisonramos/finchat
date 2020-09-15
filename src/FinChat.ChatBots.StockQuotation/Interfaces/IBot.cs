namespace FinChat.ChatBots.StockQuotation.Interfaces
{
    public interface IBot
    {
        string Name { get; }

        string Execute(string input);
    }
}
