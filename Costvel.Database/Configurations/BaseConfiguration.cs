using Costvel.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costvel.Database.Configurations;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);

    protected void ConfigureBaseProperties(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id)
            .HasName("PK_" + typeof(TEntity).Name);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("criacao")
            .IsRequired()
            .HasDefaultValueSql("NOW()");
    }
}