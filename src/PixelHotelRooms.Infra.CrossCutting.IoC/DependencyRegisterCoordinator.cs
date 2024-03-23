using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PixelHotelRooms.Infra.Data;

namespace PixelHotelRooms.Infra.CrossCutting.IoC;

public static class DependencyRegisterCoordinator
{
    private const string DEFAULT_CONNECTION = "DefaultConnection";

    public static IServiceCollection AddServicesDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddContext(configuration);

        return services;
    }

    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DEFAULT_CONNECTION);
        services.AddDbContext<RoomsContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
