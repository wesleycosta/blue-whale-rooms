using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Infra.Data;
using Orangotango.Rooms.Infra.Data.Repositories;
using Orangotango.Rooms.Infra.Extensions;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Infra.Abstractions;

namespace Orangotango.Rooms.Infra;

public class InfraModule : IModuleRegiterWithConfiguration
{
    public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddContext(configuration);
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IPublisherEvent, PublisherEvent>();

        return services;
    }
}
