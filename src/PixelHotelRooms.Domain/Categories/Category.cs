using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Domain;
using PixelHotel.Events.Rooms.Category;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;

namespace PixelHotelRooms.Domain.CategoryAggregate;

public sealed class Category : EntityBase,
    IUpdateFrom<CategoryCreateCommand, CategoryCreatedUpdatedEvent>,
    IUpdateFrom<CategoryUpdateCommand, CategoryCreatedUpdatedEvent>,
    IUpdateFrom<CategoryRemoveCommand, CategoryRemovedEvent>
{
    public string Name { get; private set; }

    public IEnumerable<CategoryCreatedUpdatedEvent> UpdateFrom(CategoryCreateCommand command)
    {
        Name = command.Name;
        GenerateId();

        yield return InstanceOfCreatedUpdatedEvent();
    }

    public IEnumerable<CategoryCreatedUpdatedEvent> UpdateFrom(CategoryUpdateCommand command)
    {
        Id = command.Id;
        Name = command.Name;

        yield return InstanceOfCreatedUpdatedEvent();
    }

    public IEnumerable<CategoryRemovedEvent> UpdateFrom(CategoryRemoveCommand command)
    {
        Id = command.Id;
        
        yield return new CategoryRemovedEvent(Id);
    }

    private CategoryCreatedUpdatedEvent InstanceOfCreatedUpdatedEvent()
        => new(Id, Name);
}
