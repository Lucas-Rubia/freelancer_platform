using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories.Proposals;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class ProposalRepository(FreelancersDbContext context) : IProposalWriteOnlyRepository, IProposalReadOnlyRepository
{
    private readonly FreelancersDbContext _dbcontext = context;
    public async Task Add(Proposal proposal)
    {
        await _dbcontext.Proposals.AddAsync(proposal);
    }

    public async Task<bool> Delete(int proposalId)
    {
        var result = await _dbcontext
            .Proposals
            .FirstOrDefaultAsync(x => x.Id == proposalId);

        if (result == null)
            return false;

        _dbcontext.Remove(result);
        return true;
    }
    public async Task<BasePagedResult<List<Proposal>?>> GetAllAsync(int userID, int pageSize, int pageNumber)
    {
        var query = _dbcontext
            .Proposals
            .AsNoTracking()
            .Where(x => x.FreelancerId == userID);

        var proposals = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new BasePagedResult<List<Proposal>?>(proposals, count);
    }

    public async Task<Proposal?> GetByIdAsync(int proposalId)
    {
        return await _dbcontext
            .Proposals
            .FirstOrDefaultAsync(x => x.Id == proposalId);
    }

    public void UpdateProposalStatus(Proposal proposal)
    {
        _dbcontext.Proposals.Update(proposal);
    }

    public void UpdateProposalInformation(Proposal proposal)
    {
        _dbcontext.Proposals.Update(proposal);
    }
}
