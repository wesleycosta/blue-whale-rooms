using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Infra.Options;
using PixelHotelRooms.Infra.Data;

namespace PixelHotelRooms.Infra.Extensions;

internal static class ContextExtensions
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(BaseDataOptions.DefaultConnection));
        services.AddDbContext<RoomsContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        return services;
    }
}
