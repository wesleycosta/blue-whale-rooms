using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Domain;

namespace PixelHotelRooms.Domain.Aggregates;

public sealed class Room : EntityBase, IAggregateRoot
{
    public string Name { get; private set; }
    public int Number { get; private set; }
    public Guid RoomCategoryId { get; private set; }
    public Category Category { get; private set; }

    public Room(string name,
        int number,
        Guid roomCategoryId,
        Category category)
    {
        GenerateId();
        Name = name;
        Number = number;
        RoomCategoryId = roomCategoryId;
        Category = category;
    }
}
