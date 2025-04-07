using Freelancers.Domain.DTOs.Responses;
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

    public async Task<BasePagedResult<List<User>?>> GetAllAsync(int pageSize, int pageNumber)
    {
        var query = _dbContext
            .Users
            .AsNoTracking()
            .OrderBy(x => x.Name);

        var users = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new BasePagedResult<List<User>?>(users, count);
    }
}
