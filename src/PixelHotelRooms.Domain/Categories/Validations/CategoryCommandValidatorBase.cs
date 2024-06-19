using FluentValidation;
using PixelHotel.Core.Domain.Validations;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;
using System.Linq.Expressions;

namespace PixelHotelRooms.Domain.CategoryAggregate.Validations;

public abstract class CategoryCommandValidatorBase<TCommand> : ValidatorBase<TCommand> where TCommand : CategoryCommandBase
{
    protected readonly ICategoryRepository CategoryRepository;

    protected CategoryCommandValidatorBase(ICategoryRepository categoryRepository)
    {
        CategoryRepository = categoryRepository;
        
        ValidateName();
        ValidateDuplicate();
    }

    protected void ValidateName()
    {
        RuleFor(command => command.Name)
          .NotNull()
          .NotEmpty()
          .WithMessage(ValidatorMessages.NotInformed(nameof(CategoryCreateCommand.Name)));

        RuleFor(command => command.Name)
           .MaximumLength(MAX_LENGTH_STRING)
           .WithMessage(ValidatorMessages.LessThanString(nameof(CategoryCreateCommand.Name)));
    }

    private void ValidateDuplicate()
      => RuleFor(command => command)
          .CustomAsync(async (command, context, cancellationToken) =>
          {
              var expression = GetExpressionCategoryWithSameName(command);
              var categoryWithSameName = await CategoryRepository.Any(expression);
              if (categoryWithSameName)
              {
                  context.AddFailure("There is already a category registered with the provided name.");
              }
          });

    private static Expression<Func<Category, bool>> GetExpressionCategoryWithSameName(TCommand command)
    {
        if (command is CategoryUpdateCommand categoryUpdateCommand)
        {
            return p => p.Name == command.Name && p.Id != categoryUpdateCommand.Id;
        }

        return p => p.Name == command.Name;
    }
}
