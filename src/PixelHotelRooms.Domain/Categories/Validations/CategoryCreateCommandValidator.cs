using FluentValidation;
using PixelHotel.Core.Domain.Validations;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;

namespace PixelHotelRooms.Domain.CategoryAggregate.Validations;

public sealed class CategoryCreateCommandValidator : ValidatorBase<CategoryCreateCommand>
{
    public CategoryCreateCommandValidator()
    {
        RuleFor(command => command.Name)
           .NotNull()
           .NotEmpty()
           .WithMessage(ValidatorMessages.NotInformed(nameof(CategoryCreateCommand.Name)));

        RuleFor(command => command.Name)
           .MaximumLength(MAX_LENGTH_STRING)
           .WithMessage(ValidatorMessages.LessThanString(nameof(CategoryCreateCommand.Name)));
    }
}
