using Microsoft.EntityFrameworkCore;
using PixelHotel.Core.Abstractions;
using PixelHotel.Infra.Configurations;
using PixelHotelRooms.Domain.CategoryAggregate;

namespace PixelHotelRooms.Infra.Data;

public class RoomsContext(DbContextOptions<RoomsContext> options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureDefault();
        modelBuilder.Entity<Category>().HasQueryFilter(filter => !filter.Removed);
    }

    public async Task<bool> Commit()
        => await SaveChangesAsync() > 0;
}
