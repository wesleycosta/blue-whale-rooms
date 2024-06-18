using MassTransit;
using PixelHotel.Core.Abstractions;
using PixelHotel.Events.Rooms.Category;
using PixelHotelRooms.Application.Abstractions;

namespace PixelHotelRooms.Application.Services;

internal class CategoryPublisher : ICategoryPublisher
{
    private readonly IBus _bus;
    private readonly ILoggerService _loggerService;

    public CategoryPublisher(IBus bus, ILoggerService loggerService)
    {
        _bus = bus;
        _loggerService = loggerService;
    }

    public async Task PublishCreatedUpdatedEvent(IEnumerable<CategoryCreatedUpdatedEvent> events)
    {
        foreach (var @event in events)
        {
            _loggerService.Information("PublishEvent", $"Publish {nameof(CategoryCreatedUpdatedEvent)}", _loggerService.GetTraceId());
            @event.TranceId = _loggerService.GetTraceId();

            await _bus.Publish(@event);
        }
    }
}
