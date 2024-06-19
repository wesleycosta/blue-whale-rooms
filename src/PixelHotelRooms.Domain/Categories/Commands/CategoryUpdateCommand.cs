namespace PixelHotelRooms.Domain.CategoryAggregate.Commands;

public sealed class CategoryUpdateCommand(Guid id,
    string name) : CategoryCommandBase(name)
{
    public Guid Id { get; init; } = id;
}
