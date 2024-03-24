using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PixelHotel.Infra.Data;
using PixelHotelRooms.Domain.Aggregates;

namespace PixelHotelRooms.Infra.Data.Mappings;

internal sealed class CategoryMapping : MappingBase, IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(MAX_LENGTH_STRING);
    }
}
