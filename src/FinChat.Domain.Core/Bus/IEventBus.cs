using System.Threading.Tasks;
using FinChat.Domain.Core.Events;

namespace FinChat.Domain.Core.Bus
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}