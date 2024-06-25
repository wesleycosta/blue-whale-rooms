using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Rooms.Application.Abstractions;

namespace Orangotango.Rooms.Application.Services;

internal sealed class RoomPublisher(ILoggerService logger,
    IPublisherEvent publisherEvent) : PublisherEventBase(logger, publisherEvent), IRoomPublisher
{
}
