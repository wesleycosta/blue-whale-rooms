using PixelHotel.Core.Bus;
using PixelHotel.Core.Bus.Abstractions;
using PixelHotel.Events.Rooms.Category;

namespace PixelHotelRooms.Application;

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
