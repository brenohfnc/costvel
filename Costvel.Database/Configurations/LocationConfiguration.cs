using Costvel.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costvel.Database.Configurations;

public class LocationConfiguration : BaseConfiguration<Location>
{
    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locais");

        builder.Property(x => x.City)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("cidade");

        builder.Property(x => x.State)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("estado");
        
        builder.Property(x => x.Country)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("pais");

        builder.Property(x => x.Coordinates)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("coordenadas");

        builder.Property(x => x.MapId)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("mapa_id");

        builder.HasMany<Cost>(x => x.Costs)
            .WithOne(x => x.Location)
            .HasForeignKey(x => x.LocationId)
            .HasConstraintName("FK_locais_custos")
            .OnDelete(DeleteBehavior.Cascade);

        ConfigureBaseProperties(builder);
    }
}