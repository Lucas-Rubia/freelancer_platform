using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class ProposalRepository(FreelancersDbContext context) : IProposalWriteOnlyRepository, IProposalReadOnlyRepository
{
    private readonly FreelancersDbContext _dbcontext = context;
    public async Task Add(Proposal proposal)
    {
        await _dbcontext.Proposals.AddAsync(proposal);
    }
}
