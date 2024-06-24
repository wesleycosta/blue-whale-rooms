using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orangotango.Infra.Data;
using Orangotango.Rooms.Domain.Rooms;

namespace Orangotango.Rooms.Infra.Data.Mappings;

internal sealed class RoomMapping : MappingBase, IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(MAX_LENGTH_STRING);

        builder.HasOne(p => p.Category)
            .WithMany(p => p.Rooms)
            .HasForeignKey(p => p.CategoryId);
    }
}
