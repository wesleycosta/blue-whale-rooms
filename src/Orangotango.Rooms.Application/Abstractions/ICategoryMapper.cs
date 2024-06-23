using Orangotango.Rooms.Application.Results;

namespace Orangotango.Rooms.Application.Abstractions;

public interface ICategoryMapper
{
    CategoryResult MapToCategoryResult(Category category);
}
