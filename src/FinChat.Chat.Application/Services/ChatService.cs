using System.Collections.Generic;
using System.Threading.Tasks;
using FinChat.Chat.Application.Interfaces;
using FinChat.Chat.Application.Models;
using FinChat.Chat.Domain.Entities;
using FinChat.Chat.Domain.Interfaces.Repositories;

namespace FinChat.Chat.Application.Services
{
    public class ChatService: IChatService
    {
        private readonly IChatRoomRepository _chatRoomRepository;

        public ChatService(IChatRoomRepository chatRoomRepository)
        {
            _chatRoomRepository = chatRoomRepository;
        }

        public Task<BasicOutput<IEnumerable<ChatRoom>>> GetChatRooms()
        {
            throw new System.NotImplementedException();
        }

        public Task<BasicOutput<ChatRoom>> GetChatRoom(string chatRoomId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BasicOutput<IEnumerable<ChatMessage>>> GetChatRoomConversation(string chatRoomId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BasicOutput<ChatRoom>> CreateChatRoom(string chatRoomName)
        {
            throw new System.NotImplementedException();
        }

        public Task<BasicOutput<string>> SendMessage(string chatRoomId, string authorId, string authorName, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}