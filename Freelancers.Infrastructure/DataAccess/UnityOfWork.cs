using Freelancers.Domain.Repositories;

namespace Freelancers.Infrastructure.DataAccess;

internal class UnityOfWork(FreelancersDbContext context) : IUnityOfWork
{
    private readonly FreelancersDbContext _dbContext = context;
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
