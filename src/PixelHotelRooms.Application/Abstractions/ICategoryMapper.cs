using PixelHotelRooms.Application.Responses;
using PixelHotelRooms.Domain.CategoryAggregate;

namespace PixelHotelRooms.Application.Abstractions;

public interface ICategoryMapper
{
    CategoryResponse MapToCategoryResponse(Category category);
}
