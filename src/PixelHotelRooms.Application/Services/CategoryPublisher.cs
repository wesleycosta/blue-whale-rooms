using MassTransit;
using PixelHotel.Events.Rooms.Category;
using PixelHotelRooms.Application.Abstractions;

namespace PixelHotelRooms.Application.Services;

internal class CategoryPublisher(IBus _bus) : ICategoryPublisher
{
    public async Task PublishCreatedUpdatedEvent(IEnumerable<CategoryCreatedUpdatedEvent> events)
    {
        foreach (var @event in events)
        {
            await _bus.Publish(@event);
        }
    }
}
