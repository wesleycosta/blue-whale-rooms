using Orangotango.Core.Bus;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Events.Rooms.Category;

namespace Orangotango.Rooms.Application;

public class TopologyConfig : IBusConfiguration
{
    public BusConfiguration GetConfiguration()
        => new()
        {
            Publishes =
                [
                   new PublishConfiguration
                   {
                       ExchangeName = "pixel-hotel-rooms-events-to-reservations",
                       Configs =
                       [
                           new PublishEventConfig
                           {
                                   EventType = typeof(CategoryCreatedUpdatedEvent),
                                   QueueName = "pixel-hotel-rooms-events-to-reservations"
                           }
                       ]
                   }
               ]
        };
}
