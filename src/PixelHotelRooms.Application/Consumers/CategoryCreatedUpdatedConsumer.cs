using MassTransit;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Bus;
using PixelHotel.Events.Rooms.Category;

namespace PixelHotelRooms.Application.Consumers;

public class CategoryCreatedUpdatedConsumer : ConsumerBase<CategoryCreatedUpdatedEvent>
{
    private readonly ILoggerService _loggerService;

    public CategoryCreatedUpdatedConsumer(ILoggerService loggerService) =>
        _loggerService = loggerService;

    public override async Task Consume(ConsumeContext<CategoryCreatedUpdatedEvent> context)
    {
        _loggerService.Information("CategoryCreatedUpdatedEvent", context.Message.AggregateId.ToString(), context.Message.TranceId);

        await Task.CompletedTask;
    }
}
