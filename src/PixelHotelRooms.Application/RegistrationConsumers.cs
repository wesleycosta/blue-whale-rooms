using PixelHotel.Core.Events;
using PixelHotel.Core.Events.Abstractions;
using PixelHotel.Events.Rooms;

namespace PixelHotelRooms.Application;

public partial class ApplicationModule
{
    internal class RegistrationConsumers : IBusConfiguration
    {
        public BusConfiguration GetConfiguration()
            => new()
            {
                Publishes =
                [
                   new PublishConfiguration
                   {
                       ExchangeName = "pixel-hotel-rooms-exchange",
                       Configs = [
                           new PublishEventConfig
                           {
                               EventType = typeof(RoomCreatedOrUpdatedEvent),
                               Queue = "pixel-hotel-rooms-events-to-reservations"
                           }
                       ]
                   }
               ]
            };
    }
}
