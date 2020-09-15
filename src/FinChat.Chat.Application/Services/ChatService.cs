using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinChat.Chat.Application.Interfaces;
using FinChat.Chat.Application.Models;
using FinChat.Chat.Data.Transactions;
using FinChat.Chat.Domain.Entities;
using FinChat.Chat.Domain.Interfaces.Repositories;
using FinChat.Chat.Domain.Notification;
using FinChat.Chat.Domain.ValueObjects;

namespace FinChat.Chat.Application.Services
{
    public class ChatService: IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChatRoomRepository _chatRoomRepository;
        private readonly IWebSocketService _webSocketService;

        public ChatService(
            IUnitOfWork unitOfWork,
            IChatRoomRepository chatRoomRepository,
            IWebSocketService webSocketService)
        {
            _unitOfWork = unitOfWork;
            _chatRoomRepository = chatRoomRepository;
            _webSocketService = webSocketService;
        }

        public BasicOutput<IEnumerable<ChatRoom>> GetChatRooms()
        {
            var output = new BasicOutput<IEnumerable<ChatRoom>>();

            var chatRooms = _chatRoomRepository.GetAll();
            output.SetOutput(chatRooms);

            return output;
        }

        public async Task<BasicOutput<ChatRoom>> GetChatRoom(string chatRoomId)
        {
            var output = new BasicOutput<ChatRoom>();

            var chatRoom = await _chatRoomRepository.GetChatRoomById(Guid.Parse(chatRoomId), false);
            chatRoom.Conversation = _chatRoomRepository.GetChatRoomConversation(chatRoom.Id, 50).ToList();
            output.SetOutput(chatRoom);

            return output;
        }

        public async Task<BasicOutput<ChatRoom>> CreateChatRoom(string chatRoomName)
        {
            var result = new BasicOutput<ChatRoom>();

            if(string.IsNullOrWhiteSpace(chatRoomName))
                result.AddNotification(new Notification("Chat name should not be empty", ENotificationType.Error, "chatRoomName"));

            if (result.Invalid)
                return result;

            var chatRoom = new ChatRoom(chatRoomName);

            if (chatRoom.Invalid)
            {
                result.AddNotifications(chatRoom.ValidationResult);
                return result;
            }

            await _chatRoomRepository.Create(chatRoom);
            await _unitOfWork.CommitAsync();

            result.SetOutput(chatRoom);
            return result;
        }

        public async Task<BasicOutput<string>> SendMessage(string chatRoomId, string authorId, string authorName, string message)
        {
            var result = new BasicOutput<string>();
            var chatRoom = await _chatRoomRepository.GetChatRoomById(Guid.Parse(chatRoomId), true);

            if(chatRoom == null)
                result.AddNotification(new Notification("Specified chat room could not be found", ENotificationType.Error, "chatRoom"));

            if (result.Invalid)
                return result;

            var author = new ChatMessageAuthor(authorId, authorName);
            var chatMessage = new ChatMessage(message, author);

            if (chatMessage.Invalid)
            {
                result.AddNotifications(chatMessage.ValidationResult);
                return result;
            }

            if (chatMessage.IsMessage)
            {
                chatRoom.AddChatMessage(chatMessage);
                _chatRoomRepository.Update(chatRoom);
                await _unitOfWork.CommitAsync();
            }

            if(chatMessage.IsCommand)
                await _webSocketService.SendCommand(chatRoom.Id.ToString(), chatMessage.Content);

            await _webSocketService
                    .SendMessage(
                        chatRoom.Id.ToString(), 
                        chatMessage);

            result.SetOutput("The message has been sent successfully");
            return result;
        }
    }
}