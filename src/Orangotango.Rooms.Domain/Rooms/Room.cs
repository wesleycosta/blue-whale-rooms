﻿using Orangotango.Rooms.Domain.Categories;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Domain;

namespace Orangotango.Rooms.Domain.Rooms;

public sealed class Room : EntityBase, IAggregateRoot
{
    public string Name { get; private set; }
    public int Number { get; private set; }
    public Guid RoomCategoryId { get; private set; }
    public Category Category { get; private set; }

    public Room(string name,
        int number,
        Guid roomCategoryId,
        Category category)
    {
        GenerateId();
        Name = name;
        Number = number;
        RoomCategoryId = roomCategoryId;
        Category = category;
    }
}