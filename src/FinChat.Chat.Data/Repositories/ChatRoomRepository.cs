using FinChat.Chat.Domain.Entities;
using FinChat.Chat.Domain.Interfaces.Repositories;
using FinChat.Chat.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinChat.Chat.Data.Repositories
{
    public class ChatRoomRepository : IChatRoomRepository
    {
        private readonly List<ChatRoom> data;

        public ChatRoomRepository()
        {
            var chatRoom = new ChatRoom("teste");
            var chatRoom1 = new ChatRoom("teste");
            var chatRoom2 = new ChatRoom("teste");


            chatRoom.Conversation = new List<ChatMessage>
            {
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 1")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 1")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 1")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 1")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 1")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 1")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 1")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 1")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 1")),
            };
            chatRoom1.Conversation = new List<ChatMessage>
            {
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 2")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 2")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 2")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 2")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 2")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 2")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 2")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 2")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 2")),
            }; 
            chatRoom2.Conversation = new List<ChatMessage>
            {
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 3")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 3")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 3")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 3")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 3")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 3")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 3")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 3")),
                new ChatMessage("test message", new ChatMessageAuthor(Guid.NewGuid().ToString(), "Authro test 3")),
            };

            data = new List<ChatRoom>() {
                chatRoom,
                chatRoom1,
                chatRoom2
            };

        }

        public async Task Create(ChatRoom chatRoom)
        {
            data.Add(chatRoom);
        }

        public async Task<IEnumerable<ChatRoom>> GetAll()
        {
            return data;
        }

        public async Task<ChatRoom> GetChatRoomById(string chatRoomId, bool includeConversation)
        {
            return data.FirstOrDefault(room => room.Id.ToString() == chatRoomId);
        }

        public async Task<IEnumerable<ChatMessage>> GetChatRoomConversation(string chatRoomId, int messages)
        {
            return data
                    .FirstOrDefault(room => room.Id.ToString() == chatRoomId)?
                    .Conversation
                    .Select(x => x)
                    .OrderByDescending(message => message.PostedAt)
                    .Take(messages);
        }

        public async Task Update(ChatRoom chatRoom)
        {
            var index = data.FindIndex(x => x.Id == chatRoom.Id);
            if (index > 1)
                data[index] = chatRoom;
        }
    }
}
