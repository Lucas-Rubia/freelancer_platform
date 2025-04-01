using Freelancers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Infrastructure.DataAccess.Mappings;

internal class ProjectMapping : BaseMapping<Project>
{
    public override void Configure(EntityTypeBuilder<Project> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("TEXT");

        builder.Property(x => x.DeadLine)
            .IsRequired()
            .HasColumnType("DATE");


        builder.Property(x => x.Bugdet)
            .IsRequired()
            .HasColumnType("NUMERIC(10,2)");


     }
}
