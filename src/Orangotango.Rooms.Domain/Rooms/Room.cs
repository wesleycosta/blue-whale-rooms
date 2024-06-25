using Orangotango.Core.Abstractions;
using Orangotango.Core.Domain;
using Orangotango.Events.Rooms.Category;
using Orangotango.Rooms.Domain.Categories;

namespace Orangotango.Rooms.Domain.Rooms;

public sealed class Room : EntityBase, IAggregateRoot
{
    public string Name { get; private set; }
    public int Number { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    public Room(string name,
        int number,
        Guid categoryId)
    {
        GenerateId();

        Name = name;
        Number = number;
        CategoryId = categoryId;
    }

    public Room SetName(string name)
    {
        Name = name;
        return this;
    }

    public Room SetNumber(int number)
    {
        Number = number;
        return this;
    }

    public Room SetCategoryId(Guid categoryId)
    {
        CategoryId = categoryId;
        return this;
    }

    public RoomUpsertedEvent GenerateUpsertedEvent()
        => new(Id, Name, Number, CategoryId);

    public RoomRemovedEvent GenerateRemovedEvent()
        => new(Id);
}
