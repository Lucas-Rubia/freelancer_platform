using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Proposals;

public interface IProposalWriteOnlyRepository
{
    Task Add(Proposal proposal);
    Task<bool> Delete(int proposalId);
    void UpdateProposalStatus(Proposal proposal);
    void UpdateProposalInformation(Proposal proposal);

}
