using System;

namespace Orangotango.Rooms.Api.InputModels;

public class RoomUpsertInputModel
{
    public string Name { get; set; }
    public int Number { get; set; }
    public Guid CategoryId{ get; set; }
}
