using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class ProprieteConfiguration : IEntityTypeConfiguration<Propriete>
{
    public void Configure(EntityTypeBuilder<Propriete> builder)
    {
        builder.Ignore(e => e.DomainEvents);

        builder.Property(t => t.Latitude)
               .HasPrecision(18, 9)
               .IsRequired();
        builder.Property(t => t.Longitude)
              .HasPrecision(18, 9)
              .IsRequired();

        builder.Property(t => t.Description)
               .HasMaxLength(255)
               .HasDefaultValue(string.Empty);

        builder.Property(t => t.AskedPrice)
               .HasColumnType("decimal(18,4)");

        builder.Property(t => t.CurrentPrice)
               .HasColumnType("decimal(18,4)");

        builder.Property(t => t.LotArea)
               .HasColumnType("decimal(10,3)");

        builder.Property(t => t.CoveredArea)
               .HasColumnType("decimal(10,2)");

        builder.OwnsOne(x => x.Address, sb =>
        {
            sb.Property(x => x.City).HasMaxLength(255).IsRequired();
            sb.Property(x => x.Line1).HasMaxLength(255).HasDefaultValue(string.Empty);
            sb.Property(x => x.Line2).HasMaxLength(255).HasDefaultValue(string.Empty);
        });
    }
}