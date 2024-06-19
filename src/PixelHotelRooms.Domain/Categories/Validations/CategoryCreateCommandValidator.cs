using PixelHotelRooms.Domain.CategoryAggregate.Commands;

namespace PixelHotelRooms.Domain.CategoryAggregate.Validations;

public sealed class CategoryCreateCommandValidator : CategoryCommandValidatorBase<CategoryCreateCommand>
{
    public CategoryCreateCommandValidator(ICategoryRepository categoryRepository) : base(categoryRepository)
    {
    }
}
