using LasmartTestContext.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LasmartTestContext.Persistence.EntityConfigurations;

/// <summary>
/// Конфигурация сущности <see cref="Comment"/>
/// </summary>
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();

        builder.HasOne(u => u.Point)
            .WithMany(u => u.Comments)
            .HasForeignKey(u => u.PointId);
    }
}