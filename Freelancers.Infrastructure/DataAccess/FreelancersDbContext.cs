using System.Reflection;
using Freelancers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Infrastructure.DataAccess;

internal class FreelancersDbContext(DbContextOptions<FreelancersDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Proposal> Proposals { get; set; }
    public DbSet<Review> Reviews { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
