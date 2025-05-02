using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Proposals;

public interface IProposalReadOnlyRepository
{
    Task<BasePagedResult<List<Proposal>?>> GetAllAsync(int userID, int pageSize, int pageNumber);
    Task<Proposal?> GetByIdAsync(int proposalId);
}
