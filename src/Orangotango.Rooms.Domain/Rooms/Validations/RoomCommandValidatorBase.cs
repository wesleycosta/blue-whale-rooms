using FluentValidation;
using Orangotango.Core.Domain.Validations;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Categories.Commands;
using Orangotango.Rooms.Domain.Rooms.Commands;
using System.Linq.Expressions;

namespace Orangotango.Rooms.Domain.Rooms.Validations;

public abstract class RoomCommandValidatorBase<TCommand> : ValidatorBase<TCommand> where TCommand : RoomCommandBase
{
    protected readonly IRoomRepository RoomRepository;
    private readonly ICategoryRepository _categoryRepository;

    protected RoomCommandValidatorBase(IRoomRepository roomRepository,
        ICategoryRepository categoryRepository)
    {
        RoomRepository = roomRepository;
        _categoryRepository = categoryRepository;

        ValidateName();
        ValidateCategory();
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

    private void ValidateCategory()
        => RuleFor(command => command.CategoryId)
        .CustomAsync(async (categoryId, context, cancellationToken) =>
        {
            var category = await _categoryRepository.GetById(categoryId);
            if (category is null)
            {
                context.AddFailure(ValidatorMessages.NotFound(nameof(Category)));
            }
        });

    private void ValidateDuplicate()
        => RuleFor(command => command)
        .CustomAsync(async (command, context, cancellationToken) =>
        {
            var expression = GetExpressionRoomWithSameName(command);
            var categoryWithSameName = await RoomRepository.Any(expression);
            if (categoryWithSameName)
            {
                context.AddFailure("There is already a room registered with the provided name.");
            }
        });

    private static Expression<Func<Room, bool>> GetExpressionRoomWithSameName(TCommand command)
    {
        if (command is RoomUpdateCommand categoryUpdateCommand)
            return p => p.Name == command.Name && p.Id != categoryUpdateCommand.Id;

        return p => p.Name == command.Name;
    }
}
