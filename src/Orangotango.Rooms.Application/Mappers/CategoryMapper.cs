using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Application.Results;
using Orangotango.Rooms.Domain.Categories;

namespace Orangotango.Rooms.Application.Mappers;

internal sealed class CategoryMapper : ICategoryMapper
{
    public CategoryResult MapToCategoryResult(Category category)
        => new()
        {
            Id = category.Id,
            Name = category.Name
        };
}
