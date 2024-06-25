using Orangotango.Rooms.Application.Results;

namespace Orangotango.Rooms.Application.Abstractions;

public interface IRoomQueryService : IQueryServiceBase<RoomResult>
{
    Task<IEnumerable<RoomResultFull>> Search(string searchValue);
}
