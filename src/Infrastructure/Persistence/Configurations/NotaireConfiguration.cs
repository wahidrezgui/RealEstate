using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class NotaireConfiguration : IEntityTypeConfiguration<Notaire>
{
    public void Configure(EntityTypeBuilder<Notaire> builder)
    {
        builder.Property(t => t.Name)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

        builder.HasOne(t => t.Photo)
                    .WithOne(t => t.Notaire)
                    .HasForeignKey<PhotoNotaire>(t => t.NotaireId);

        builder.OwnsOne(x => x.Address, sb =>
        {
            sb.Property(x => x.City).HasMaxLength(255).IsRequired();
            sb.Property(x => x.Line1).HasMaxLength(255).HasDefaultValue(string.Empty);
            sb.Property(x => x.Line2).HasMaxLength(255).HasDefaultValue(string.Empty);
        });
    }
}

public class PhotoNotaireConfiguration : IEntityTypeConfiguration<PhotoNotaire>
{
    public void Configure(EntityTypeBuilder<PhotoNotaire> builder)
    {
        builder.HasOne(y => y.Notaire)
               .WithOne(t => t.Photo)
               .HasForeignKey<Notaire>(t => t.PhotoId);
    }
}

public class PhotoPropertyConfiguration : IEntityTypeConfiguration<PhotoProperty>
{
    public void Configure(EntityTypeBuilder<PhotoProperty> builder)
    {
        builder.HasOne(y => y.Propriete);
    }
}