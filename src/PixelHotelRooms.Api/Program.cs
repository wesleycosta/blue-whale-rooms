using PixelHotel.Api;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Domain.Aggregates;
using PixelHotelRooms.Infra;
using PixelHotelRooms.Infra.Data;
using System.Reflection;

var assemblies = new Assembly[]
{
    typeof(ICategoryService).Assembly,
    typeof(RoomsContext).Assembly,
    typeof(Category).Assembly
};

var app = new WebAppBuilder()
    .BuildDefault(args)
    .WithServices(assemblies, (services, configuration) => services.AddInfraDependencies(configuration))
    .WithDefaultAppConfig()
    .WithApplyMigrate<RoomsContext>()
    .Create();

app.Run();
