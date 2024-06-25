using Orangotango.Rooms.Application.Results;
using Orangotango.Rooms.Domain.Rooms;

namespace Orangotango.Rooms.Application.Abstractions;

public interface IRoomMapper
{
    RoomResult MapToRoomResult(Room room);
    RoomResultFull MapToRoomResultFull(Room room);
}
