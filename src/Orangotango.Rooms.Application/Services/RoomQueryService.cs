using Orangotango.Core.Services;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Application.Results;
using Orangotango.Rooms.Domain.Rooms;
using System.Linq.Expressions;

namespace Orangotango.Rooms.Application.Services;

internal sealed class RoomQueryService(IRoomRepository _repository,
    IRoomMapper _mapper) : QueryServiceBase, IRoomQueryService
{
    public async Task<Result> GetById(Guid id)
    {
        var roomResult = await GetRoomResultById(id);
        if (roomResult is null)
            return NotFoundResult(nameof(Room));

        return SuccessfulResult(roomResult);
    }

    public async Task<IEnumerable<RoomResult>> Search(string searchValue)
    {
        Expression<Func<Room, bool>> filter = p => true;
        if (!string.IsNullOrEmpty(searchValue))
            filter = room => room.Name.Contains(searchValue);

        return await _repository.GetByExpression(filter, p => _mapper.MapToRoomResult(p));
    }

    private async Task<RoomResult> GetRoomResultById(Guid id)
        => await _repository.GetFirstByExpression(category => category.Id == id, 
            p => _mapper.MapToRoomResult(p));
}
