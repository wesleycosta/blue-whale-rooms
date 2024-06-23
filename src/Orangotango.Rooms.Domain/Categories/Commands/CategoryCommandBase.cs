using Orangotango.Core.Domain;

namespace Orangotango.Rooms.Domain.Categories.Commands;

public abstract class CategoryCommandBase(string name) : CommandBase
{
    public string Name { get; private set; } = name;
}
