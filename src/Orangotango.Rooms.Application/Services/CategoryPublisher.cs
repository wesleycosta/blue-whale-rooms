using MassTransit;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Enums;
using Orangotango.Events.Rooms.Category;
using Orangotango.Rooms.Application.Abstractions;
using Event = Orangotango.Core.Events.Event;

namespace Orangotango.Rooms.Application.Services;

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
        => _loggerService.Information(nameof(OperationLogs.EventPublished),
            $"Publish {eventName}",
            @event,
            _loggerService.GetTraceId());
}
