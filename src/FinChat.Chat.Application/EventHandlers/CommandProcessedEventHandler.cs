using System;
using System.Threading.Tasks;
using FinChat.Chat.Application.Events;
using FinChat.Chat.Application.Interfaces;
using FinChat.Domain.Core.Bus;
using Newtonsoft.Json;

namespace FinChat.Chat.Application.EventHandlers
{
    public class CommandProcessedEventHandler: IEventHandler<CommandProcessedEvent>
    {
        private readonly IChatService _chatService;

        public CommandProcessedEventHandler(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task Handle(CommandProcessedEvent @event)
        {
            await _chatService
                .SendMessage(
                    @event.ChatRoomId, 
                    @event.ProcessorId, 
                    @event.ProcessorName, 
                    @event.Content);
        }
    }
}