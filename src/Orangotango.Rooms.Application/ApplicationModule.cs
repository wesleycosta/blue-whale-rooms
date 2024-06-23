using Microsoft.Extensions.DependencyInjection;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Application.Handlers;
using Orangotango.Rooms.Application.Mappers;
using Orangotango.Rooms.Application.Services;
using Orangotango.Rooms.Domain.Categories.Commands;

namespace Orangotango.Rooms.Application;

public class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryMapper, CategoryMapper>();
        services.AddScoped<ICategoryPublisher, CategoryPublisher>();

        services.AddCommandHandler<CategoryCreateCommand, CategoryCreateCommandHandler>();
        services.AddCommandHandler<CategoryUpdateCommand, CategoryUpdateCommandHandler>();
        services.AddCommandHandler<CategoryRemoveCommand, CategoryRemoveCommandHandler>();

        return services;
    }
}
