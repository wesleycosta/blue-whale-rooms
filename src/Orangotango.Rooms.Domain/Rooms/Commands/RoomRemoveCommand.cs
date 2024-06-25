using Orangotango.Core.Domain;

namespace Orangotango.Rooms.Domain.Rooms.Commands;

public sealed class RoomRemoveCommand(Guid id) : CommandBase
{
    public Guid Id { get; private set; } = id;
}
