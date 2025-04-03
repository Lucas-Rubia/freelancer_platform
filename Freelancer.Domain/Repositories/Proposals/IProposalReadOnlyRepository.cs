using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Proposals;

public interface IProposalReadOnlyRepository
{
    Task<List<Proposal>?> GetAllAsync();
}
