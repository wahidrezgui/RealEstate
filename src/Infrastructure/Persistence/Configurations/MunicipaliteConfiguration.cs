using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class MunicipaliteConfiguration : IEntityTypeConfiguration<Municipalite>
{
    public void Configure(EntityTypeBuilder<Municipalite> builder)
    {
        builder.Property(t => t.Name)
               .HasMaxLength(255)
               .IsRequired();
        builder.Property(t => t.PostalCode)
              .IsRequired();

        //builder.OwnsMany(x => x.Addresses, sb =>
        //{
        //    sb.Property(x => x.City).HasMaxLength(255).IsRequired();
        //    sb.Property(x => x.Line1).HasMaxLength(255).HasDefaultValue(string.Empty);
        //    sb.Property(x => x.Line2).HasMaxLength(255).HasDefaultValue(string.Empty);
        //    sb.Property(x => x.Municipalite).IsRequired();
        //});
    }
}