using FluentValidation;
using Orangotango.Core.Domain.Validations;
using Orangotango.Rooms.Domain.Categories.Commands;
using Orangotango.Rooms.Domain.Rooms;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class CategoryRemoveCommandValidator : ValidatorBase<CategoryRemoveCommand>
{
    private readonly IRoomRepository _roomRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRemoveCommandValidator(IRoomRepository roomRepository,
        ICategoryRepository categoryRepository)
    {
        _roomRepository = roomRepository;
        _categoryRepository = categoryRepository;

        ValidateIfExists();
        ValidateRoomLinkedToCategory();
    }

    private void ValidateIfExists()
        => RuleFor(command => command.Id)
        .CustomAsync(async (id, context, cancellationToken) =>
        {
            var categoryExists = await _categoryRepository.Any(p => p.Id == id);
            if (!categoryExists)
            {
                context.AddFailure(ValidatorMessages.NotFound(nameof(Category)));
            }
        });

    private void ValidateRoomLinkedToCategory()
      => RuleFor(command => command.Id)
      .CustomAsync(async (id, context, cancellationToken) =>
      {
          var isRoomLinkedToCategory = await _roomRepository.Any(p => p.CategoryId == id);
          if (isRoomLinkedToCategory)
          {
              context.AddFailure("You cannot delete a category that is linked to a room.");
          }
      });

}
