using PixelHotel.Core.Domain;

namespace PixelHotelRooms.Domain.Commands;

public sealed class CategoryCreateCommand : CommandBase
{
    public required string Name { get; init; }
}
