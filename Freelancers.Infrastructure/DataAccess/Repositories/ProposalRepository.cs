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

    public async Task<List<Proposal>?> GetAllAsync()
    {
        return await _dbcontext.Proposals.AsNoTracking().ToListAsync();
    }
}
