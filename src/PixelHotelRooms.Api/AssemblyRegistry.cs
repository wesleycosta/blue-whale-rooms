using PixelHotelRooms.Application;
using PixelHotelRooms.Domain;
using PixelHotelRooms.Infra;
using System.Collections.Generic;
using System.Reflection;

namespace PixelHotelRooms.Api;

public static class AssemblyRegistry
{
    public static IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(ApplicationModule).Assembly;
        yield return typeof(DomainModule).Assembly;
        yield return typeof(InfraModule).Assembly;
    }
}
