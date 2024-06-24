using Orangotango.Events.Rooms.Category;

namespace Orangotango.Rooms.Application.Abstractions;

public interface ICategoryPublisher
{
    Task PublishCategoryUpsertedEvent(CategoryUpsertedEvent @event);
    Task PublishRemovedEvent(CategoryRemovedEvent @event);
}
