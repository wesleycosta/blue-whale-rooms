using PixelHotel.Core.Domain;

namespace PixelHotelRooms.Domain.Commands;

public sealed class CategoryUpdateCommand : CommandBase
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}
