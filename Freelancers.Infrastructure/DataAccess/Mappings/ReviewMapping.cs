using Freelancers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Infrastructure.DataAccess.Mappings;

internal class ReviewMapping : BaseMapping<Review>
{
    public override void Configure(EntityTypeBuilder<Review> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Rating)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(x => x.Comment)
            .IsRequired()
            .HasColumnType("TEXT");
     }
}
