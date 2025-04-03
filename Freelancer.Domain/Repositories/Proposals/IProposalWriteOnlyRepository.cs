using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Proposals;

public interface IProposalWriteOnlyRepository
{
    Task Add(Proposal proposal);
}
