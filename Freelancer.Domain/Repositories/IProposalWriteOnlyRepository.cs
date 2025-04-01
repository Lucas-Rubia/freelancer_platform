using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories;

public interface IProposalWriteOnlyRepository
{
    Task Add(Proposal proposal);
}
