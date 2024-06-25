using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Rooms;
using Orangotango.Rooms.Domain.Rooms.Commands;

namespace Orangotango.Rooms.Domain.Rooms.Validations;

public sealed class RoomCreateCommandValidator(IRoomRepository roomRepository,
    ICategoryRepository categoryRepository) : RoomCommandValidatorBase<RoomCreateCommand>(roomRepository, categoryRepository)
{
}
