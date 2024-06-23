using Orangotango.Core.Domain;

namespace Orangotango.Rooms.Domain.Categories;

public sealed class Category : EntityBase
{
    public string Name { get; private set; }

    public Category(string name)
    {
        GenerateId();
        Name = name;
    }

    public void SetName(string name)
        => Name = name;
}
