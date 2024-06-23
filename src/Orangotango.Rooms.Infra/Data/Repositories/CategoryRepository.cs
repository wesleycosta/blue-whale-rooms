using Orangotango.Infra.Data;
using Orangotango.Rooms.Domain.Categories;

namespace Orangotango.Rooms.Infra.Data.Repositories;

internal class CategoryRepository(RoomsContext context) : RepositoryBase<Category>(context), ICategoryRepository
{
}
