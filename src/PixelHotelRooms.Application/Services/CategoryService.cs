using PixelHotel.Core.Services;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Application.Responses;
using PixelHotelRooms.Domain.CategoryAggregate;
using System.Linq.Expressions;

namespace PixelHotelRooms.Application.Services;

internal sealed class CategoryService(ICategoryRepository categoryRepository,
    ICategoryMapper categoryMapper) : QueryServiceBase, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly ICategoryMapper _categoryMapper = categoryMapper;

    public async Task<Result> GetById(Guid id)
    {
        var categoryResponse = await GetCategoryResponseById(id);
        if (categoryResponse is null)
        {
            return NotFoundResult(nameof(Category));
        }

        return SuccessfulResult(categoryResponse);
    }

    public async Task<IEnumerable<CategoryResult>> Search(string searchValue)
    {
        Expression<Func<Category, bool>> filter = p => true;
        if (!string.IsNullOrEmpty(searchValue))
        {
            filter = category => category.Name.Contains(searchValue);
        }

        return await _categoryRepository.GetByExpression(filter, p => _categoryMapper.MapToCategoryResult(p));
    }

    private async Task<CategoryResult> GetCategoryResponseById(Guid id)
        => await _categoryRepository.GetFirstByExpression(category => category.Id == id,
            p => _categoryMapper.MapToCategoryResult(p));
}
