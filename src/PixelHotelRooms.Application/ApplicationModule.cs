using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Extensions;
using PixelHotelRooms.Application.Abstractions;
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
        services.AddScoped<ICategoryPublisher, CategoryPublisher>();

        services.AddCommandHandler<CategoryCreateCommand, CategoryCreateCommandHandler>();
        services.AddCommandHandler<CategoryUpdateCommand, CategoryUpdateCommandHandler>();

        return services;
    }
}
