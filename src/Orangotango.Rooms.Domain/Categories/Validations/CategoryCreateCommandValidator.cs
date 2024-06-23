using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Categories.Commands;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class CategoryCreateCommandValidator : CategoryCommandValidatorBase<CategoryCreateCommand>
{
    public CategoryCreateCommandValidator(ICategoryRepository categoryRepository) : base(categoryRepository)
    {
    }
}
