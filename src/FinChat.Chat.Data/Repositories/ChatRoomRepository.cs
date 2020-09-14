using FinChat.Chat.Domain.Entities;
using FinChat.Chat.Domain.Interfaces.Repositories;
using FinChat.Chat.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinChat.Chat.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinChat.Chat.Data.Repositories
{
    public class ChatRoomRepository : IChatRoomRepository
    {
        private readonly FinChatDbContext _context;

        public ChatRoomRepository(FinChatDbContext context)
        {
            _context = context;
        }

        public async Task Create(ChatRoom chatRoom)
        {
            await _context.AddAsync(chatRoom);
        }

        public IEnumerable<ChatRoom> GetAll()
        {
            return _context.ChatRooms.AsEnumerable();
        }

        public async Task<ChatRoom> GetChatRoomById(Guid chatRoomId, bool includeConversation)
        {
            var rooms = _context.ChatRooms;

            if (includeConversation)
                rooms.Include(x => x.Conversation);

            return await rooms.FirstOrDefaultAsync(room => room.Id == chatRoomId);
        }

        public IEnumerable<ChatMessage> GetChatRoomConversation(Guid chatRoomId, int messagesAmount)
        {
            return _context
                    .ChatMessages
                    .Where(x => x.ChatRoom.Id == chatRoomId)
                    .OrderByDescending(message => message.PostedAt)
                    .Take(messagesAmount);
        }

        public void Update(ChatRoom chatRoom)
        {
            _context.ChatRooms.Update(chatRoom);
        }
    }
}
