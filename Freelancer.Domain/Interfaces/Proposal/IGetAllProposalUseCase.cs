using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Proposal;

namespace Freelancers.Domain.Interfaces.Proposal;

public interface IGetAllProposalUseCase
{
    Task<BasePagedResponse<List<ResponseProposalDTO>?>> Execute(int userID, int pageSize, int pageNumber);
}
