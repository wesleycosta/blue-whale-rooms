using PixelHotel.Api;
using PixelHotelRooms.Infra.Data;

var app = new WebAppBuilder()
    .BuildDefault(args)
    .WithApplyMigrate<RoomsContext>()
    .Create();

app.Run();
