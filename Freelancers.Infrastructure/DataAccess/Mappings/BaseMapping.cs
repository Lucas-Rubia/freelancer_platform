using Freelancers.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Infrastructure.DataAccess.Mappings;

internal class BaseMapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseModel
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("now()");
        
        builder.Property(x => x.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("now()");
    }
}
