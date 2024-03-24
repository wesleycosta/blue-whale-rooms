using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Extensions;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;
using PixelHotelRooms.Domain.CategoryAggregate.Validations;

namespace PixelHotelRooms.Domain;

public class DomainModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddValidator<CategoryCreateCommand, CategoryCreateCommandValidator>();

        return services;
    }
}
