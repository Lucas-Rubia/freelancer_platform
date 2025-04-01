using Freelancers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Infrastructure.DataAccess.Mappings;

internal class ProposalMapping : BaseMapping<Proposal>
{
    public override void Configure(EntityTypeBuilder<Proposal> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ProposedValue)
            .IsRequired()
            .HasColumnType("NUMERIC(10,2)");

        builder.Property(x => x.Message)
            .IsRequired()
            .HasColumnType("TEXT");

        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnType("INT");
     }
}
