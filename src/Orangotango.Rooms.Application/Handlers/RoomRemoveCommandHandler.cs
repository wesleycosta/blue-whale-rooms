using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Domain.Rooms;
using Orangotango.Rooms.Domain.Rooms.Commands;

namespace Orangotango.Rooms.Application.Handlers;

internal sealed class RoomRemoveCommandHandler(IUnitOfWork unitOfWork,
    IValidator<RoomRemoveCommand> validator,
    IRoomMapper _mapper,
    IRoomRepository _repository,
    IRoomPublisher _publisher) : CommandHandlerBase<RoomRemoveCommand>(unitOfWork, validator)
{
    public override async Task<Result> Handle(RoomRemoveCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var room = await _repository.GetById(command.Id);
        _repository.SoftDelete(room);

        if (await Commit())
        {
            await _publisher.Publish(room.GenerateRemovedEvent());
            return SuccessfulResult(_mapper.MapToRoomResult(room));
        }

        return BadResult();
    }
}
