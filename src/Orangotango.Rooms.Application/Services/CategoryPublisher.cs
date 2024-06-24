using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Core.Events;
using Orangotango.Rooms.Application.Abstractions;

namespace Orangotango.Rooms.Application.Services;

internal class CategoryPublisher(ILoggerService logger,
    IPublisherEvent _publisherEvent) : PublisherEventBase(logger), ICategoryPublisher
{
    private readonly ILoggerService _logger = logger;

    public async Task PublishEvent<T>(T @event) where T : Event
    {
        @event.TranceId = _logger.GetTraceId();
        await _publisherEvent.Publish(@event);
        LogPublishEvent(@event);
    }
}
