using MassTransit;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Events;
using PixelHotel.Events.Rooms;

namespace PixelHotelRooms.Application.Consumers;

public class RoomCreatedUpdatedConsumer : ConsumerBase<RoomCreatedOrUpdatedEvent>
{
    private readonly ILoggerService _loggerService;

    public RoomCreatedUpdatedConsumer(ILoggerService loggerService) =>
        _loggerService = loggerService;

    public override async Task Consume(ConsumeContext<RoomCreatedOrUpdatedEvent> context)
    {
        _loggerService.Information("RoomCreatedUpdatedConsumer", context.Message.AggregateId.ToString(), context.Message.TranceId);

        await Task.CompletedTask;
    }
}

public class RoomRemovedEventConsumer : ConsumerBase<RoomRemovedEvent>
{
    private readonly ILoggerService _loggerService;

    public RoomRemovedEventConsumer(ILoggerService loggerService) =>
        _loggerService = loggerService;

    public override async Task Consume(ConsumeContext<RoomRemovedEvent> context)
    {
        _loggerService.Information("RoomRemovedEventConsumer", context.Message.AggregateId.ToString(), context.Message.TranceId);

        await Task.CompletedTask;
    }
}

public class ReservationsConsumer2 : ConsumerBase<RoomCreatedOrUpdatedEvent>
{
    private readonly ILoggerService _loggerService;

    public ReservationsConsumer2(ILoggerService loggerService) =>
        _loggerService = loggerService;

    public override async Task Consume(ConsumeContext<RoomCreatedOrUpdatedEvent> context)
    {
        _loggerService.Information("ReservationsConsumer2", context.Message.AggregateId.ToString(), context.Message.TranceId);

        await Task.CompletedTask;
    }
}
