using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Proposals;

public interface IProposalReadOnlyRepository
{
    Task<BasePagedResult<List<ProposalWithTitleProject>?>> GetAllAsync(int userID, int pageSize, int pageNumber);
    Task<Proposal?> GetByIdAsync(int proposalId);
}
