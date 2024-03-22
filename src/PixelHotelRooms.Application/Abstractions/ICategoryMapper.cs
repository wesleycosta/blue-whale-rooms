using PixelHotelRooms.Application.Responses;
using PixelHotelRooms.Domain.Aggregates;

namespace PixelHotelRooms.Application.Abstractions;

public interface ICategoryMapper
{
    CategoryResponse MapToCategoryResponse(Category category);
}
