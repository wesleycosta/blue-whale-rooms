using PixelHotel.Core.Domain;

namespace PixelHotelRooms.Domain.CategoryAggregate.Commands;

public sealed class CategoryRemoveCommand(Guid id) : CommandBase
{
    public Guid Id { get; private set; } = id;
}
