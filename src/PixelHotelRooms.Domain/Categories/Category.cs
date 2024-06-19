using PixelHotel.Core.Domain;

namespace PixelHotelRooms.Domain.CategoryAggregate;

public sealed class Category : EntityBase
{
    public string Name { get; private set; }

    public Category(string name)
    {
        GenerateId();
        Name = name;
    }

    public void SetName(string name)
        => Name = name;
}
