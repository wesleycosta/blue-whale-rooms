using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Extensions;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Application.Handlers;
using Orangotango.Rooms.Application.Mappers;
using Orangotango.Rooms.Application.Services;
using Orangotango.Rooms.Domain.Categories.Commands;
using Orangotango.Rooms.Domain.Rooms.Commands;

namespace Orangotango.Rooms.Application;

public class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        AddCategoryModule(services);
        AddRoomModule(services);

        return services;
    }

    private static void AddCategoryModule(IServiceCollection services)
    {
        services.AddScoped<ICategoryMapper, CategoryMapper>();
        services.AddScoped<ICategoryPublisher, CategoryPublisher>();
        services.AddScoped<ICategoryQueryService, CategoryQueryService>();

        services.AddCommandHandler<CategoryCreateCommand, CategoryCreateCommandHandler>();
        services.AddCommandHandler<CategoryUpdateCommand, CategoryUpdateCommandHandler>();
        services.AddCommandHandler<CategoryRemoveCommand, CategoryRemoveCommandHandler>();
    }

    private static void AddRoomModule(IServiceCollection services)
    {
        services.AddScoped<IRoomMapper, RoomMapper>();
        services.AddScoped<IRoomPublisher, RoomPublisher>();
        services.AddScoped<IRoomQueryService, RoomQueryService>();

        services.AddCommandHandler<RoomCreateCommand, RoomCreateCommandHandler>();
        services.AddCommandHandler<RoomUpdateCommand, RoomUpdateCommandHandler>();
        services.AddCommandHandler<RoomRemoveCommand, RoomRemoveCommandHandler>();
    }
}
