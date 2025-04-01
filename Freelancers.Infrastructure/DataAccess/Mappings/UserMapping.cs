using Freelancers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Infrastructure.DataAccess.Mappings;

internal class UserMapping : BaseMapping<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnType("CHAR(60)");


        builder.Property(x => x.UserType)
            .IsRequired()
            .HasColumnType("INT");
     }
}
