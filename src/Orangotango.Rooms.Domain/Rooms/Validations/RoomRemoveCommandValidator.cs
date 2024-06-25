using FluentValidation;
using Orangotango.Core.Domain.Validations;
using Orangotango.Rooms.Domain.Rooms;
using Orangotango.Rooms.Domain.Rooms.Commands;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class RoomRemoveCommandValidator : ValidatorBase<RoomRemoveCommand>
{
    private readonly IRoomRepository _roomRepository;

    public RoomRemoveCommandValidator(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
        ValidateIfExists();
    }

    private void ValidateIfExists()
        => RuleFor(command => command.Id)
        .CustomAsync(async (id, context, cancellationToken) =>
        {
            var exists = await _roomRepository.Any(p => p.Id == id);
            if (!exists)
            {
                context.AddFailure(ValidatorMessages.NotFound(nameof(Room)));
            }
        });
}
