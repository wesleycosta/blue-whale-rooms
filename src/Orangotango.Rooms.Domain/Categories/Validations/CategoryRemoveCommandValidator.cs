using FluentValidation;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Categories.Commands;
using Orangotango.Core.Domain.Validations;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class CategoryRemoveCommandValidator : ValidatorBase<CategoryRemoveCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRemoveCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        ValidateIfExists();
    }

    private void ValidateIfExists()
        => RuleFor(command => command)
        .CustomAsync(async (command, context, cancellationToken) =>
        {
            var categoryExists = await _categoryRepository.Any(p => p.Id == command.Id);
            if (!categoryExists)
                context.AddFailure(ValidatorMessages.NotFound(nameof(Category)));
        });
}
