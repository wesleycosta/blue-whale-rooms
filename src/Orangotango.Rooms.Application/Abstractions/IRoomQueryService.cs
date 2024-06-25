using Orangotango.Rooms.Application.Results;

namespace Orangotango.Rooms.Application.Abstractions;

public interface IRoomQueryService : IQueryServiceBase<RoomBasicResult>
{
    Task<IEnumerable<RoomResult>> Search(string searchValue);
}
