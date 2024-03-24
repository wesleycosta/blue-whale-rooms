using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Events.Abstractions;

namespace PixelHotelRooms.Infra.Data;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly RoomsContext _context;
    private readonly IPublisherEvent _publisherEvent;

    public UnitOfWork(RoomsContext dbContext,
        IPublisherEvent publisherEvent)
    {
        _context = dbContext;
        _publisherEvent = publisherEvent;
    }

    public async Task<bool> Commit()
    {
        return await _context.Commit();
    }
}
