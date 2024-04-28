using PixelHotel.Events.Rooms.Category;

namespace PixelHotelRooms.Application.Abstractions;

public interface ICategoryPublisher
{
    Task PublishCreatedUpdatedEvent(IEnumerable<CategoryCreatedUpdatedEvent> events);
}
