namespace Orangotango.Rooms.Domain.Categories.Commands;

public sealed class CategoryUpdateCommand(Guid id, string name) : CategoryCommandBase(name)
{
    public Guid Id { get; private set; } = id;
}
