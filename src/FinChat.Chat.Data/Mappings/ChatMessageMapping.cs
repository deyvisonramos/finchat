using System.Security.Cryptography.X509Certificates;
using FinChat.Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinChat.Chat.Data.Mappings
{
    public class ChatMessageMapping: IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                    .IsRequired()
                    .ValueGeneratedNever();
            builder.Property(x => x.Content)
                    .HasMaxLength(800)
                    .IsRequired();
            builder.Property(x => x.PostedAt).IsRequired();
            
            builder.Ignore(x => x.FormattedContent);
            builder.Ignore(x => x.IsCommand);
            builder.Ignore(x => x.IsMessage);
            builder.Ignore(x => x.IsWarning);

            builder.OwnsOne(x => x.Author, (author) =>
            {
                author.Property(x => x.Id).IsRequired();
                author.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}