using Orangotango.Core.Domain;

namespace Orangotango.Rooms.Domain.Categories.Commands;

public sealed class CategoryRemoveCommand(Guid id) : CommandBase
{
    public Guid Id { get; private set; } = id;
}
