using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Domain.Rooms;
using Orangotango.Rooms.Domain.Rooms.Commands;

namespace Orangotango.Rooms.Application.Handlers;

internal sealed class RoomUpdateCommandHandler(IUnitOfWork unitOfWork,
    IValidator<RoomUpdateCommand> validator,
    IRoomMapper _mapper,
    IRoomRepository _repository,
    IRoomPublisher _publisher) : CommandHandlerBase<RoomUpdateCommand>(unitOfWork, validator)
{
    public override async Task<Result> Handle(RoomUpdateCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var room = await _repository.GetById(command.Id);
        room.SetName(command.Name)
            .SetNumber(command.Number)
            .SetCategoryId(command.CategoryId);

        _repository.Update(room);

        if (await Commit())
        {
            await _publisher.Publish(room.GenerateUpsertedEvent());
            return SuccessfulResult(_mapper.MapToRoomResult(room));
        }

        return BadResult();
    }
}
