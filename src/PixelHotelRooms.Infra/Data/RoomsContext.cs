using Microsoft.EntityFrameworkCore;
using PixelHotel.Core.Abstractions;
using PixelHotel.Infra.Configurations;
using PixelHotelRooms.Domain.CategoryAggregate;

namespace PixelHotelRooms.Infra.Data;

public class RoomsContext : DbContext, IUnitOfWork
{
    public RoomsContext(DbContextOptions<RoomsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureDefault();
        modelBuilder.Entity<Category>().HasQueryFilter(p => !p.Removed);
    }

    public async Task<bool> Commit()
        => await SaveChangesAsync() > 0;
}
