using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class ContractRepository(FreelancersDbContext context): IContractReadOnlyRepository
{
    private readonly FreelancersDbContext _dbconxtext = context;

    public async Task<List<Contract>?> GetAllAsync()
    {
        return await _dbconxtext.Contracts.AsNoTracking().ToListAsync();
    }
}
