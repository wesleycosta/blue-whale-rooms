using PixelHotel.Core.Domain;

namespace PixelHotelRooms.Domain.CategoryAggregate.Commands;

public sealed class CategoryRemoveCommand : CommandBase
{
    public required Guid Id { get; init; }
}
