using Orangotango.Infra.Data;
using Orangotango.Rooms.Domain.Rooms;

namespace Orangotango.Rooms.Infra.Data.Repositories;

internal class RoomRepository(RoomsContext context) : RepositoryBase<Room>(context), IRoomRepository
{
}
