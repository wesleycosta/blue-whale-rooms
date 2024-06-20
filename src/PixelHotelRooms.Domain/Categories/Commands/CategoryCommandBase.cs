using PixelHotel.Core.Domain;

namespace PixelHotelRooms.Domain.CategoryAggregate.Commands;

public abstract class CategoryCommandBase(string name) : CommandBase
{
    public string Name { get; private set; } = name;
}
