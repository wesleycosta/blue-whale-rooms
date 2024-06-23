using Orangotango.Rooms.Api;
using Orangotango.Api;
using OrangotangoRooms.Infra.Data;

var app = new WebAppBuilder()
    .BuildDefault(args)
    .WithDefaultServices()
    .WithServicesFromAssemblies(AssemblyRegistry.GetAssemblies())
    .WithDefaultAppConfig()
    .WithApplyMigrate<RoomsContext>()
    .Create();

app.Run();
