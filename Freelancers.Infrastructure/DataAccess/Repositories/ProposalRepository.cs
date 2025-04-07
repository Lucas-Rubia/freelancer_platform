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

    public async Task<BasePagedResult<List<Proposal>?>> GetAllAsync(int pageSize, int pageNumber)
    {
        var query = _dbcontext
            .Proposals
            .AsNoTracking();

        var proposals = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new BasePagedResult<List<Proposal>?>(proposals, count);
    }
}
