using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Requests.Proposal;

namespace Freelancers.Domain.Interfaces.Proposal;

public interface IProcessProposalInformationUseCase
{
    Task<BaseResponse<ResponseProposalInformationDTO>> Execute(RequestProposalInformationDTO request);
}
