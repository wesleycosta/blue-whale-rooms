using Orangotango.Rooms.Application.Results;
using Orangotango.Rooms.Domain.Categories;

namespace Orangotango.Rooms.Application.Abstractions;

public interface ICategoryMapper
{
    CategoryResult MapToCategoryResult(Category category);
}
