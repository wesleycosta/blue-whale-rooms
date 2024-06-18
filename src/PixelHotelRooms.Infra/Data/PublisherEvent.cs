using MassTransit;
using PixelHotel.Core.Bus.Abstractions;
using EventBase = PixelHotel.Core.Events.Event;

namespace PixelHotelRooms.Infra.Data;

public class PublisherEvent(IBus _bus) : IPublisherEvent
{
    public async Task Publish<TEvent>(TEvent @event) where TEvent : EventBase
        => await _bus.Publish(@event);
}

