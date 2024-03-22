using PixelHotel.Core.Abstractions;

namespace PixelHotelRooms.Infra.Data;

public sealed class UnitOfWork(RoomsContext _context) : IUnitOfWork
{
    public async Task<bool> Commit()
        => await SaveChanges() > 0;

    public async Task<int> SaveChanges()
        => await _context.SaveChangesAsync();
}
