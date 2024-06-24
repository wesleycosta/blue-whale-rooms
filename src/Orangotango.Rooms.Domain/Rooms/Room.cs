using Orangotango.Core.Abstractions;
using Orangotango.Core.Domain;
using Orangotango.Rooms.Domain.Categories;

namespace Orangotango.Rooms.Domain.Rooms;

public sealed class Room : EntityBase, IAggregateRoot
{
    public string Name { get; private set; }
    public int Number { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
}
