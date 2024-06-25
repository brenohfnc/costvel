using Costvel.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costvel.Database.Configurations;

public class CostConfiguration : BaseConfiguration<Cost>
{
    public override void Configure(EntityTypeBuilder<Cost> builder)
    {
        builder.ToTable("custos");

        builder.Property(x => x.Value)
            .IsRequired()
            .HasColumnName("valor");

        builder.Property(x => x.RequesterIp)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("ip_solicitante");

        builder
            .Property(x => x.LocationId)
            .IsRequired()
            .HasColumnName("cidade_id");

        builder
            .Property(x => x.CostTypeId)
            .IsRequired()
            .HasColumnName("tipo_id");

        builder.HasOne<Location>(x => x.Location);
        builder.HasOne<CostType>(x => x.CostType);

        ConfigureBaseProperties(builder);
    }
}