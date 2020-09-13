using System.Data;
using FluentValidation;

namespace FinChat.Chat.Domain.Entities.Validators
{
    internal class ChatRoomValidator: AbstractValidator<ChatRoom>
    {
        public ChatRoomValidator()
        {
            RuleFor(a => a.Name)
                .Length(3, int.MaxValue)
                .WithMessage("Chat Room's name should be at least 3 chars long");

            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Chat Room's name should not be empty or null");
        }
    }
}