using PixelHotel.Core.Abstractions;

namespace PixelHotelRooms.Infra.Data;

public sealed class UnitOfWork(RoomsContext _context) : IUnitOfWork
{
    public async Task<bool> Commit()
        => await _context.Commit();
}
