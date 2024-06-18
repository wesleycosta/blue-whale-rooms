using PixelHotel.Core.Bus;
using PixelHotel.Core.Bus.Abstractions;
using PixelHotel.Events.Rooms;
using PixelHotelRooms.Application.Consumers;

namespace PixelHotelRooms.Application;

public class RegistrationConsumers : IBusConfiguration
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
                                   EventType = typeof(RoomCreatedOrUpdatedEvent),
                                   QueueName = "pixel-hotel-rooms-events-to-reservations"
                           }
                       ]
                   }
               ],
            Receives = [
                new ReceiveConfiguration
                {
                    ExchangeName = "pixel-hotel-rooms-events-to-reservations",
                    QueueName = "pixel-hotel-rooms-events-to-reservations",
                    Consumers = [
                        typeof(RoomCreatedUpdatedConsumer)
                    ]
                }
            ]
        };
}
