using Orangotango.Events.Rooms.Category;

namespace Orangotango.Rooms.Application.Abstractions;

public interface ICategoryPublisher
{
    Task PublishCreatedUpdatedEvent(CategoryCreatedUpdatedEvent @event);
    Task PublishRemovedEvent(CategoryRemovedEvent @event);
}
