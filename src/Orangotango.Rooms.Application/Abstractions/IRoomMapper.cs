using Orangotango.Rooms.Application.Results;
using Orangotango.Rooms.Domain.Rooms;

namespace Orangotango.Rooms.Application.Abstractions;

public interface IRoomMapper
{
    RoomBasicResult MapToRoomResult(Room room);
    RoomResult MapToRoomResultFull(Room room);
}
