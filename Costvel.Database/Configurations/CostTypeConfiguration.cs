using Costvel.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costvel.Database.Configurations;

public class CostTypeConfiguration : BaseConfiguration<CostType>
{
    public override void Configure(EntityTypeBuilder<CostType> builder)
    {
        builder.ToTable("tipo_custos");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("nome");

        builder.Property(x => x.Description)
            .HasMaxLength(1024)
            .HasColumnName("descricao");
        
        builder.Property(x => x.Order)
            .IsRequired()
            .HasColumnName("ordem");

        builder
            .HasIndex(x => x.Order)
            .IsUnique();

        builder.HasMany<Cost>(x => x.Costs)
            .WithOne(x => x.CostType)
            .HasForeignKey(x => x.CostTypeId)
            .HasConstraintName("FK_CostType_Cost")
            .OnDelete(DeleteBehavior.Cascade);

        ConfigureBaseProperties(builder);
    }
}