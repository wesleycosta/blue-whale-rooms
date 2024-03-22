namespace PixelHotelRooms.Infra.CrossCutting.IoC;

public static class InfraDependencyInjection
{
    public static IServiceCollection AddDependencyInjections(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfraBasicServices();

        new DataModule().RegisterServices(services);

        return services;
    }
}
