using FinChat.Chat.Data.Mappings;
using FinChat.Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinChat.Chat.Data.Context
{
    public class FinChatDbContext: DbContext
    {
        public FinChatDbContext(DbContextOptions<FinChatDbContext> options): base(options)
        {
            
        }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatRoomMapping());
            modelBuilder.ApplyConfiguration(new ChatMessageMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}