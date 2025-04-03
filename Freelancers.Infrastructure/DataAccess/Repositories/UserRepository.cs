using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class UserRepository(FreelancersDbContext context) : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly FreelancersDbContext _dbContext = context;

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task<List<User>?> GetAllAsync()
    {
        return await _dbContext.Users.AsNoTracking().ToListAsync();
    }
}
