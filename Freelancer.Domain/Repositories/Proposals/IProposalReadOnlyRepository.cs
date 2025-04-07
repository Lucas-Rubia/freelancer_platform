using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Proposals;

public interface IProposalReadOnlyRepository
{
    Task<BasePagedResult<List<Proposal>?>> GetAllAsync(int pageSize, int pageNumber);
}
