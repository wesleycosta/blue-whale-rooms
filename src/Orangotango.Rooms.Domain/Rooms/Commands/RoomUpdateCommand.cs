namespace Orangotango.Rooms.Domain.Rooms.Commands;

public sealed class RoomUpdateCommand(Guid id,
    string name,
    int number,
    Guid categoryId) : RoomCommandBase(name, number, categoryId)
{
    public Guid Id { get; private set; } = id;
}
