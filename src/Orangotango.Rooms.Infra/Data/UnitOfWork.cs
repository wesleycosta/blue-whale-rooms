using Orangotango.Core.Abstractions;

namespace Orangotango.Rooms.Infra.Data;

public sealed class UnitOfWork(RoomsContext _context) : IUnitOfWork
{
    public async Task<bool> Commit()
        => await _context.Commit();
}
