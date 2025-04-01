using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class UserRepository(FreelancersDbContext context) : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly FreelancersDbContext _dbContext = context;

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }
}
