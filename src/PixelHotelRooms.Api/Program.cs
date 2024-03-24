using PixelHotel.Api;
using PixelHotelRooms.Api;
using PixelHotelRooms.Infra.Data;

var app = new WebAppBuilder()
    .BuildDefault(args)
    .WithDefaultServices()
    .WithServicesFromAssemblies(AssemblyRegistry.GetAssemblies())
    .WithDefaultAppConfig()
    .WithApplyMigrate<RoomsContext>()
    .Create();

app.Run();
