using FinChat.Chat.Data.Mappings;
using FinChat.Chat.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinChat.Chat.Data.Context
{
    public class FinChatDbContext: IdentityDbContext<IdentityUser>
    {
        public FinChatDbContext(DbContextOptions<FinChatDbContext> options): base(options)
        {
            
        }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ChatRoomMapping());
            modelBuilder.ApplyConfiguration(new ChatMessageMapping());

        }
    }
}