using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Application.Responses;
using PixelHotelRooms.Domain.CategoryAggregate;

namespace PixelHotelRooms.Application.Mappers;

internal sealed class CategoryMapper : ICategoryMapper
{
    public CategoryResponse MapToCategoryResponse(Category category)
        => new()
        {
            Id = category.Id,
            Name = category.Name
        };
}
