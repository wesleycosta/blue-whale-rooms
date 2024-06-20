using Microsoft.EntityFrameworkCore;
using PixelHotel.Core.Abstractions;
using PixelHotel.Infra.Configurations;

namespace PixelHotelRooms.Infra.Data;

public class RoomsContext(DbContextOptions<RoomsContext> options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ConfigureDefault();

    public async Task<bool> Commit()
        => await SaveChangesAsync() > 0;
}
