using Freelancers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Infrastructure.DataAccess.Mappings;

internal class ContractMapping : BaseMapping<Contract>
{
    public override void Configure(EntityTypeBuilder<Contract> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.StartDate)
            .IsRequired()
            .HasColumnType("DATE");

        builder.Property(x => x.EndDate)
            .IsRequired()
            .HasColumnType("DATE");

        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnType("INT");
     }
}
