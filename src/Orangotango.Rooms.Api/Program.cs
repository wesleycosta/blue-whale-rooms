using Orangotango.Api;
using Orangotango.Rooms.Api;
using Orangotango.Rooms.Infra.Data;

var app = new WebAppBuilder()
    .BuildDefault(args)
    .WithDefaultServices()
    .WithServicesFromAssemblies(AssemblyRegistry.GetAssemblies())
    .WithDefaultAppConfig()
    .WithApplyMigrate<RoomsContext>()
    .Create();

app.Run();
