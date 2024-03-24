using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Domain.Aggregates;
using PixelHotelRooms.Infra.Data;
using System.Collections.Generic;
using System.Reflection;

namespace PixelHotelRooms.Api;

public static class AssemblyRegistry
{
    public static IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(ICategoryService).Assembly;
        yield return typeof(Category).Assembly;
        yield return typeof(RoomsContext).Assembly;
    }
}
