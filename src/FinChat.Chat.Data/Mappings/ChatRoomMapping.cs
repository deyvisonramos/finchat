using FinChat.Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinChat.Chat.Data.Mappings
{
    public class ChatRoomMapping: IEntityTypeConfiguration<ChatRoom>
    {
        public void Configure(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);

            builder
                .HasMany(x => x.Conversation)
                .WithOne(x => x.ChatRoom)
                .IsRequired();
        }
    }
}