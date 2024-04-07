using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Events;
using PixelHotel.Core.Events.Abstractions;
using PixelHotel.Infra.Configurations;

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
        var committeeSuccessfullyCompleted = await _context.Commit();
        if (committeeSuccessfullyCompleted)
        {
            await _publisherEvent.PublishDomainEvents(_context);
        }

        return committeeSuccessfullyCompleted;
    }
}

public class PublisherEvent : IPublisherEvent
{
    public async Task Publish<TEvent>(TEvent @event) where TEvent : Event
    {
        // TODO: arrumar
        await Task.CompletedTask;
    }
}

