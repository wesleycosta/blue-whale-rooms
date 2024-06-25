using FluentValidation;
using Orangotango.Core.Domain.Validations;
using Orangotango.Rooms.Domain.Rooms;
using Orangotango.Rooms.Domain.Rooms.Commands;
using Orangotango.Rooms.Domain.Rooms.Validations;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class RoomUpdateCommandValidator(IRoomRepository roomRepository,
    ICategoryRepository categoryRepository) : RoomCommandValidatorBase<RoomUpdateCommand>(roomRepository, categoryRepository)
{
    private void ValidateIfExists()
        => RuleFor(command => command)
        .CustomAsync(async (command, context, cancellationToken) =>
        {
            var exists = await RoomRepository.Any(p => p.Id == command.Id);
            if (!exists)
            {
                context.AddFailure(ValidatorMessages.NotFound(nameof(Room)));
            }
        });
}
