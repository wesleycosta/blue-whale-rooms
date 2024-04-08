using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Events;
using PixelHotel.Core.Events.Abstractions;
using PixelHotel.Core.Extensions;
using PixelHotel.Events.Rooms;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Application.Consumers;
using PixelHotelRooms.Application.Handlers;
using PixelHotelRooms.Application.Mappers;
using PixelHotelRooms.Application.Services;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;

namespace PixelHotelRooms.Application;

public class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryMapper, CategoryMapper>();
        services.AddCommandHandler<CategoryCreateCommand, CategoryCreateCommandHandler>();
        services.AddScoped<IConsumer<RoomCreatedOrUpdatedEvent>, RoomCreatedUpdatedConsumer>();

        return services;
    }

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
