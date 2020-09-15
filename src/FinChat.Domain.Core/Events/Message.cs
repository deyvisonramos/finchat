using MediatR;

namespace FinChat.Domain.Core.Events
{
    public class Message: IRequest<bool>
    {
        protected Message()
        {
            Type = GetType().Name;
        }

        public string Type { get; protected set; }
    }
}