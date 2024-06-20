using FluentValidation;
using PixelHotel.Core.Domain.Validations;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;

namespace PixelHotelRooms.Domain.CategoryAggregate.Validations;

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
            {
                context.AddFailure(ValidatorMessages.NotFound(nameof(Category)));
            }
        });
}
