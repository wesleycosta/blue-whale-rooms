using PixelHotel.Core.Services;
using PixelHotelRooms.Application.Responses;

namespace PixelHotelRooms.Application.Abstractions;

public interface ICategoryService
{
    Task<Result> GetById(Guid id);
    Task<IEnumerable<CategoryResult>> Search(string searchValue);
}
