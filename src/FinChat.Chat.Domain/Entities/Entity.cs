using System;
using System.ComponentModel.DataAnnotations.Schema;
using FinChat.Chat.Domain.Notification;
using FluentValidation;
using FluentValidation.Results;

namespace FinChat.Chat.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        [NotMapped]
        public bool Valid { get; private set; }
        [NotMapped]
        public bool Invalid => !Valid;
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
	}
}