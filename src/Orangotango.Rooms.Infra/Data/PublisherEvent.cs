using MassTransit;
using Orangotango.Core.Bus.Abstractions;
using EventBase = Orangotango.Core.Events.Event;

namespace Orangotango.Rooms.Infra.Data;

public class PublisherEvent(IBus _bus) : IPublisherEvent
{
    public async Task Publish<TEvent>(TEvent @event) where TEvent : EventBase
        => await _bus.Publish(@event);
}

