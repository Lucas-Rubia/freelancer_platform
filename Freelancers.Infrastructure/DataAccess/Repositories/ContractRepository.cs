using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class ContractRepository(FreelancersDbContext context): IContractReadOnlyRepository
{
    private readonly FreelancersDbContext _dbconxtext = context;

    public async Task<BasePagedResult<List<Contract>?>> GetAllAsync(int pageSize, int pageNumber)
    {
        var query = _dbconxtext
            .Contracts
            .AsNoTracking();

        var contract = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new BasePagedResult<List<Contract>?>(contract, count);
    }
}
