using Orangotango.Core.Results;

namespace Orangotango.Rooms.Application.Results;

public class RoomBasicResult : ResultBase
{
    public string Name { get; set; }
    public int Number { get; set; }
    public Guid CategoryId { get; set; }
}
