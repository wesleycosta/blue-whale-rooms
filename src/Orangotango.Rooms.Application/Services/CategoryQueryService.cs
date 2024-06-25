using Orangotango.Core.Services;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Application.Results;
using Orangotango.Rooms.Domain.Categories;
using System.Linq.Expressions;

namespace Orangotango.Rooms.Application.Services;

internal sealed class CategoryQueryService(ICategoryMapper _mapper,
    ICategoryRepository _repository) : QueryServiceBase, ICategoryQueryService
{
    public async Task<Result> GetById(Guid id)
    {
        var categoryResult = await GetCategoryResultById(id);
        if (categoryResult is null)
            return NotFoundResult(nameof(Category));

        return SuccessfulResult(categoryResult);
    }

    public async Task<IEnumerable<CategoryResult>> Search(string searchValue)
    {
        Expression<Func<Category, bool>> filter = p => true;
        if (!string.IsNullOrEmpty(searchValue))
            filter = category => category.Name.Contains(searchValue);

        return await _repository.GetByExpression(filter, p => _mapper.MapToCategoryResult(p));
    }

    private async Task<CategoryResult> GetCategoryResultById(Guid id)
        => await _repository.GetFirstByExpression(category => category.Id == id,
            p => _mapper.MapToCategoryResult(p));
}
