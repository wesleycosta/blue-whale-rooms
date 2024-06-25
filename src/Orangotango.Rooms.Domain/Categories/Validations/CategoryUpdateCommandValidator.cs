using FluentValidation;
using Orangotango.Core.Domain.Validations;
using Orangotango.Rooms.Domain.Categories.Commands;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class CategoryUpdateCommandValidator : CategoryCommandValidatorBase<CategoryUpdateCommand>
{
    public CategoryUpdateCommandValidator(ICategoryRepository categoryRepository) : base(categoryRepository)
        => ValidateIfExists();

    private void ValidateIfExists()
        => RuleFor(command => command)
        .CustomAsync(async (command, context, cancellationToken) =>
        {
            var categoryExists = await CategoryRepository.Any(p => p.Id == command.Id);
            if (!categoryExists)
            {
                context.AddFailure(ValidatorMessages.NotFound(nameof(Category)));
            }
        });
}
