using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace FinChat.Chat.Domain.Notification
{
    public abstract class NotificationContext
    {
        protected NotificationContext()
        {
            Notifications = new List<Notification>();
        }

        [NotMapped]
        public List<Notification> Notifications { get; }
        
        [NotMapped]
        [JsonIgnore]
        public bool Invalid => Notifications.Any(msg => msg.Type == ENotificationType.Error);

        public void AddNotification(Notification message)
        {
            if (message != null)
                Notifications.Add(message);

        }

        public void AddNotifications(IEnumerable<Notification> messages)
        {
            if(messages != null)
                Notifications.AddRange(messages);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(new Notification(error.ErrorMessage, ENotificationType.Error, error.ErrorCode));
            }
        }
    }
}