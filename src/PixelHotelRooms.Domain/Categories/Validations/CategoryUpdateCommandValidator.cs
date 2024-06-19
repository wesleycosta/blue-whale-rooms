using FluentValidation;
using PixelHotel.Core.Domain.Validations;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;

namespace PixelHotelRooms.Domain.CategoryAggregate.Validations;

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
