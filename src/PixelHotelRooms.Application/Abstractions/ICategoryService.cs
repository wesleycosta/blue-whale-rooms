using PixelHotel.Core.Services;

namespace PixelHotelRooms.Application.Abstractions;

public interface ICategoryService
{
    Task<Result> GetById(Guid id);
}
