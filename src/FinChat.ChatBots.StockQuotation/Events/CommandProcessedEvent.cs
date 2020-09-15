using FinChat.Domain.Core.Events;

namespace FinChat.ChatBots.StockQuotation.Events
{
    public class CommandProcessedEvent: Event
    {
        public CommandProcessedEvent(string content, string chatRoomId, string processorId, string processorName)
        {
            Content = content;
            ChatRoomId = chatRoomId;
            ProcessorId = processorId;
            ProcessorName = processorName;
        }
        public string Content { get; }
        public string ChatRoomId { get; }
        public string ProcessorId { get; }
        public string ProcessorName { get; }
    }
}