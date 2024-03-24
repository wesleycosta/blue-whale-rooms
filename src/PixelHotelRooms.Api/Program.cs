using PixelHotel.Api;
using PixelHotelRooms.Api.Controllers;
using PixelHotelRooms.Infra;
using PixelHotelRooms.Infra.Data;

var app = new WebAppBuilder()
    .BuildDefault(args)
    .WithServices<CategoryController>((services, configuration) =>
    {
        services.AddInfraDependencies(configuration);
    })
    .WithApp()
    .WithApplyMigrate<RoomsContext>()
    .Create();

app.Run();
