using Microsoft.Extensions.DependencyInjection;
using Orangotango.Rooms.Domain.Categories.Commands;
using Orangotango.Rooms.Domain.Categories.Validations;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Extensions;

namespace Orangotango.Rooms.Domain;

public class DomainModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddValidator<CategoryCreateCommand, CategoryCreateCommandValidator>();
        services.AddValidator<CategoryUpdateCommand, CategoryUpdateCommandValidator>();
        services.AddValidator<CategoryRemoveCommand, CategoryRemoveCommandValidator>();

        return services;
    }
}
