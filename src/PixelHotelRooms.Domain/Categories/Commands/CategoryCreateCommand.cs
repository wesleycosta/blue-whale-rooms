using PixelHotel.Core.Domain;

namespace PixelHotelRooms.Domain.CategoryAggregate.Commands;

public sealed class CategoryCreateCommand : CommandBase
{
    public required string Name { get; init; }
}
