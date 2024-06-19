namespace PixelHotelRooms.Domain.CategoryAggregate.Commands;

public sealed class CategoryCreateCommand(string name) : CategoryCommandBase(name)
{
}
