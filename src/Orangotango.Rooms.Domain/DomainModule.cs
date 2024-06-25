using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Extensions;
using Orangotango.Rooms.Domain.Categories.Commands;
using Orangotango.Rooms.Domain.Categories.Validations;
using Orangotango.Rooms.Domain.Rooms.Commands;
using Orangotango.Rooms.Domain.Rooms.Validations;

namespace Orangotango.Rooms.Domain;

public class DomainModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddValidator<CategoryCreateCommand, CategoryCreateCommandValidator>();
        services.AddValidator<CategoryUpdateCommand, CategoryUpdateCommandValidator>();
        services.AddValidator<CategoryRemoveCommand, CategoryRemoveCommandValidator>();

        services.AddValidator<RoomCreateCommand, RoomCreateCommandValidator>();
        services.AddValidator<RoomUpdateCommand, RoomUpdateCommandValidator>();
        services.AddValidator<RoomRemoveCommand, RoomRemoveCommandValidator>();

        return services;
    }
}
