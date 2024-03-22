using PixelHotel.Infra.Data;
using PixelHotelRooms.Domain.Aggregates;
using PixelHotelRooms.Domain.Repositories;

namespace PixelHotelRooms.Infra.Data.Repositories;

internal class CategoryRepository(RoomsContext context) : RepositoryBase<Category>(context), ICategoryRepository
{
}
