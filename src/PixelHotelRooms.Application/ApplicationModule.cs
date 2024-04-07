using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
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

    internal class RegistrationConsumers : IRegistrationConsumers
    {
        public void Register(IBusRegistrationConfigurator busRegistrationConfigurator)
        {
            busRegistrationConfigurator.AddConsumer<RoomCreatedUpdatedConsumer>();
            busRegistrationConfigurator.AddConsumer<RoomRemovedEventConsumer>();
            busRegistrationConfigurator.AddConsumer<ReservationsConsumer2>();
        }

        public void Register(IServiceCollection services, IRabbitMqBusFactoryConfigurator config, IRegistrationContext context)
        {
            config.Publish<RoomCreatedUpdatedConsumer>(x =>
            {
                x.Durable = true;
                x.BindQueue(x.Exchange.ExchangeName, "room-queue");
                x.BindQueue(x.Exchange.ExchangeName, "reservations-queue");
            });

            config.ReceiveEndpoint("room-queue", e =>
            {
                e.ConfigureConsumer<RoomCreatedUpdatedConsumer>(context);
                e.ConfigureConsumer<RoomRemovedEventConsumer>(context);
                e.Bind<RoomCreatedOrUpdatedEvent>();
                e.Bind<RoomRemovedEvent>();
            });

            config.ReceiveEndpoint("reservations-queue", e =>
            {
                e.ConfigureConsumer<ReservationsConsumer2>(context);
                e.Bind<RoomCreatedOrUpdatedEvent>();
            });
        }
    }
}
