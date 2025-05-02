using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class ContractRepository(FreelancersDbContext context): IContractReadOnlyRepository, IContractWriteOnlyRepository
{
    private readonly FreelancersDbContext _dbcontext = context;

    public async Task Add(Contract contract)
    {
        await _dbcontext.Contracts.AddAsync(contract);
    }

    public async Task<BasePagedResult<List<Contract>?>> GetAllAsync(int userID, int pageSize, int pageNumber)
    {
        var query = _dbcontext
            .Contracts
            .AsNoTracking()
            .Include(x => x.Proposal)
            .ThenInclude(x => x.Project)
            .Where(x => x.Proposal.Project.UserId == userID || x.Proposal.FreelancerId == userID);


        var contract = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new BasePagedResult<List<Contract>?>(contract, count);
    }

    public async Task<Contract?> GetByIdAsync(int contractId)
    {
        return await _dbcontext
        .Contracts
        .FirstOrDefaultAsync(x => x.Id == contractId);
    }

    public void UpdateContractStatus(Contract contract)
    {
        _dbcontext.Contracts.Update(contract);
    }
}
