using PixelHotel.Core.Events.Abstractions;
using PixelHotel.Infra.Data;

namespace PixelHotelRooms.Infra.Data;

public class RoomsContext(IPublisherEvent publisherEvent) : ContextBase(publisherEvent)
{
}
