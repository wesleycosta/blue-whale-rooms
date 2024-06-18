using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Extensions;
using PixelHotel.Events.Rooms.Category;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Application.Consumers;
using PixelHotelRooms.Application.Handlers;
using PixelHotelRooms.Application.Mappers;
using PixelHotelRooms.Application.Services;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;

namespace PixelHotelRooms.Application;

public partial class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryPublisher, CategoryPublisher>();
        services.AddScoped<ICategoryMapper, CategoryMapper>();
        services.AddCommandHandler<CategoryCreateCommand, CategoryCreateCommandHandler>();
        services.AddScoped<IConsumer<CategoryCreatedUpdatedEvent>, CategoryCreatedUpdatedConsumer>();

        return services;
    }
}
