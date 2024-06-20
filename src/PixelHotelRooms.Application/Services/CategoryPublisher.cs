using MassTransit;
using PixelHotel.Core.Abstractions;
using PixelHotel.Events.Rooms.Category;
using PixelHotel.Infra.Logger;
using PixelHotelRooms.Application.Abstractions;
using Event = PixelHotel.Core.Events.Event;

namespace PixelHotelRooms.Application.Services;

internal class CategoryPublisher(IBus bus, ILoggerService loggerService) : ICategoryPublisher
{
    private readonly IBus _bus = bus;
    private readonly ILoggerService _loggerService = loggerService;

    public async Task PublishCreatedUpdatedEvent(CategoryCreatedUpdatedEvent @event)
    {
        LogPublishEvent(@event, nameof(CategoryCreatedUpdatedEvent));
        @event.TranceId = _loggerService.GetTraceId();

        await _bus.Publish(@event);
    }

    public async Task PublishRemovedEvent(CategoryRemovedEvent @event)
    {
        LogPublishEvent(@event, nameof(CategoryRemovedEvent));
        @event.TranceId = _loggerService.GetTraceId();

        await _bus.Publish(@event);
    }

    private void LogPublishEvent(Event @event, string eventName)
        => _loggerService.Information(nameof(OperationLogs.PublishedEvent),
            $"Publish {eventName}",
            @event,
            _loggerService.GetTraceId());
}
