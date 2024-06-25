using Orangotango.Core.Domain;
using Orangotango.Events.Rooms.Category;
using Orangotango.Rooms.Domain.Rooms;

namespace Orangotango.Rooms.Domain.Categories;

public sealed class Category : EntityBase
{
    public string Name { get; private set; }

    public IEnumerable<Room> Rooms { get; private set; }

    public Category(string name)
    {
        GenerateId();
        Name = name;
    }

    public Category SetName(string name)
    {
        Name = name;
        return this;
    }

    public CategoryUpsertedEvent GenerateUpsertedEvent()
        => new(Id, Name);

    public CategoryRemovedEvent GenerateRemovedEvent()
        => new(Id);
}
