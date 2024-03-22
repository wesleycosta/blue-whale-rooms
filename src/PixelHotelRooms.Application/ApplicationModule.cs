using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Extensions;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Application.Handlers;
using PixelHotelRooms.Application.Mappers;
using PixelHotelRooms.Domain.Commands;

namespace PixelHotelRooms.Application;

public class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICategoryMapper, CategoryMapper>();
        services.AddCommandHandler<CategoryCreateCommand, CategoryCreateCommandHandler>();

        return services;
    }
}
