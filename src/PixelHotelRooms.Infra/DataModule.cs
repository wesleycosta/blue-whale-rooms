using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotelRooms.Domain.Repositories;
using PixelHotelRooms.Infra.Data.Repositories;

namespace PixelHotelRooms.Infra;

public class DataModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
