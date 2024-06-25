using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Domain.Rooms;
using Orangotango.Rooms.Domain.Rooms.Commands;

namespace Orangotango.Rooms.Application.Handlers;

internal sealed class RoomCreateCommandHandler(IUnitOfWork _unitOfWork,
    IValidator<RoomCreateCommand> _validator,
    IRoomMapper _mapper,
    IRoomRepository _repository,
    IRoomPublisher _publisher) : CommandHandlerBase<RoomCreateCommand>(_unitOfWork, _validator)
{
    public override async Task<Result> Handle(RoomCreateCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var room = new Room(command.Name,
            command.Number,
            command.CategoryId);

        _repository.Add(room);

        if (await Commit())
        {
            await _publisher.Publish(room.GenerateUpsertedEvent());
            return SuccessfulResult(_mapper.MapToRoomResult(room));
        }

        return BadResult();
    }
}
