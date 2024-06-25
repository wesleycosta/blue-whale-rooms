using Orangotango.Core.Domain;

namespace Orangotango.Rooms.Domain.Rooms.Commands;

public abstract class RoomCommandBase(string name,
    int number,
    Guid categoryId) : CommandBase
{
    public string Name { get; private set; } = name;
    public int Number { get; private set; } = number;
    public Guid CategoryId { get; private set; } = categoryId;
}
