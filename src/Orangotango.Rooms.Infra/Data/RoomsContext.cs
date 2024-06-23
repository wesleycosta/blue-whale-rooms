using Microsoft.EntityFrameworkCore;
using Orangotango.Core.Abstractions;
using Orangotango.Infra.Configurations;
using OrangotangoRooms.Domain.CategoryAggregate;

namespace Orangotango.Rooms.Infra.Data;

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
