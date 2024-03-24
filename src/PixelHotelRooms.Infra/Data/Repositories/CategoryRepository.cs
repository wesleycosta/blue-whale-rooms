using PixelHotel.Infra.Data;
using PixelHotelRooms.Domain.CategoryAggregate;

namespace PixelHotelRooms.Infra.Data.Repositories;

internal class CategoryRepository(RoomsContext context) : RepositoryBase<Category>(context), ICategoryRepository
{
}
