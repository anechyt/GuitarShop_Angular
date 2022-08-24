using GuitarShop.Domain.Entities;
using GuitarShop.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuitarShop.Persistence.Configurations
{
    public class GuitarConfiguration : IEntityTypeConfiguration<Guitar>
    {
        public void Configure(EntityTypeBuilder<Guitar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, x => new Name(x))
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(x => x.Size)
                .HasConversion(x => x.Value, x => new Size(x))
                .IsRequired();
            builder.Property(x => x.NumberOfStrings)
                .HasConversion(x => x.Value, x => new NumberOfStrings(x))
                .IsRequired();
            builder.Property(x => x.Colour)
                .HasConversion(x => x.Value, x => new Colour(x))
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(x => x.Price)
                .HasConversion(x => x.Value, x => new Price(x))
                .IsRequired();
            builder.Property(x => x.PhotoUrl)
                .HasConversion(x => x.Value, x => new PhotoUrl(x))
                .IsRequired();
        }
    }
}
