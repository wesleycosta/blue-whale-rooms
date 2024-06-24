using Orangotango.Core.Domain;
using Orangotango.Rooms.Domain.Rooms;
using System.Security.Principal;

namespace Orangotango.Rooms.Domain.Categories;

public sealed class Category : EntityBase
{
    public string Name { get; private set; }

    public IEnumerable<Room> Rooms { get; set; }

    public Category(string name)
    {
        GenerateId();
        Name = name;
    }

    public void SetName(string name)
        => Name = name;
}
