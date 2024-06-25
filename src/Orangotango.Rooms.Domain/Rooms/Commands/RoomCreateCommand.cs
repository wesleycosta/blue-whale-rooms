
namespace Orangotango.Rooms.Domain.Rooms.Commands;

public sealed class RoomCreateCommand(string name,
    int number,
    Guid categoryId) : RoomCommandBase(name, number, categoryId)
{
}
