using Freelancers.Domain.DTOs.Requests.Proposal;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Proposal;

namespace Freelancers.Domain.Interfaces.Proposal;

public interface IProcessProposalStatusUseCase
{
    Task<BaseResponse<ResponseProposalStatusDTO>> Execute(RequestProposalStatusDTO request);
}
