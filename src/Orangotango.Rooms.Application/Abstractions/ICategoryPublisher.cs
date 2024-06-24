using Orangotango.Core.Events;

namespace Orangotango.Rooms.Application.Abstractions;

public interface ICategoryPublisher
{
    Task PublishEvent<T>(T @event) where T : Event;
}
