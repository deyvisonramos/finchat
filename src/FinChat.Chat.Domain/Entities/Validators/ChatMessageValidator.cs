using FluentValidation;

namespace FinChat.Chat.Domain.Entities.Validators
{
    public class ChatMessageValidator: AbstractValidator<ChatMessage>
    {
        public ChatMessageValidator()
        {
            RuleFor(x => x.Author.Name)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("invalidAuthorName")
                .WithMessage("Author's name is required");
            
            RuleFor(x => x.Author.Id)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("invalidAuthorId")
                .WithMessage("Author's identification is required");

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .WithErrorCode("emptyChatMessageContent")
                .WithMessage("It is not possible to post an empty message");
        }
    }
}