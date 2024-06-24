using Microsoft.EntityFrameworkCore;
using Orangotango.Core.Abstractions;
using Orangotango.Infra.Configurations;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Rooms;

namespace Orangotango.Rooms.Infra.Data;

public class ReservationsContext(DbContextOptions<ReservationsContext> options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureDefault();
        
        modelBuilder.Entity<Category>().HasQueryFilter(filter => !filter.Removed);
        modelBuilder.Entity<Room>().HasQueryFilter(filter => !filter.Removed);
    }

    public async Task<bool> Commit()
        => await SaveChangesAsync() > 0;
}
