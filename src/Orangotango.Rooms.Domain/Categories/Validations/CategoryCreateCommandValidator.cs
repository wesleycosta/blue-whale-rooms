using Orangotango.Rooms.Domain.Categories.Commands;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class CategoryCreateCommandValidator(ICategoryRepository categoryRepository)
    : CategoryCommandValidatorBase<CategoryCreateCommand>(categoryRepository)
{
}
