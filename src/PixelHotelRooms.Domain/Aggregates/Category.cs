using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Domain;
using PixelHotel.Events.Rooms.Category;
using PixelHotelRooms.Domain.Commands;

namespace PixelHotelRooms.Domain.Aggregates;

public sealed class Category : EntityBase,
    IUpdateFrom<CategoryCreateCommand>,
    IUpdateFrom<CategoryUpdateCommand>,
    IUpdateFrom<CategoryRemoveCommand>
{
    public string Name { get; private set; }

    public void UpdateFrom(CategoryCreateCommand command)
    {
        Name = command.Name;

        GenerateId();
        AddCreatedUpdatedEvent();
    }

    public void UpdateFrom(CategoryUpdateCommand command)
    {
        Id = command.Id;
        Name = command.Name;

        AddCreatedUpdatedEvent();
    }

    public void UpdateFrom(CategoryRemoveCommand command)
    {
        Id = command.Id;
        RemoveAndAddEvent<CategoryRemovedEvent>();
    }

    private void AddCreatedUpdatedEvent()
    {
        var createdUpdatedEvent = new CategoryCreatedUpdatedEvent(Id, Name);
        AddEvent(createdUpdatedEvent);
    }
}
