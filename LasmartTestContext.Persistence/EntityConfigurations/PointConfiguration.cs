using LasmartTestContext.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LasmartTestContext.Persistence.EntityConfigurations;

/// <summary>
/// Конфигурация сущности <see cref="Point"/>
/// </summary>
public class PointConfiguration : IEntityTypeConfiguration<Point>
{
    public void Configure(EntityTypeBuilder<Point> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();
    }
}