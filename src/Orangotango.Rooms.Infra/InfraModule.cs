using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Infra.Abstractions;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Rooms;
using Orangotango.Rooms.Infra.Data;
using Orangotango.Rooms.Infra.Data.Repositories;
using Orangotango.Rooms.Infra.Extensions;

namespace Orangotango.Rooms.Infra;

public class InfraModule : IModuleRegiterWithConfiguration
{
    public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddContext(configuration);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IPublisherEvent, PublisherEvent>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();

        return services;
    }
}
