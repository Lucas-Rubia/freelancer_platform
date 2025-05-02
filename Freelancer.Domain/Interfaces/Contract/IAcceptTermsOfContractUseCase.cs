using Freelancers.Domain.DTOs.Requests.Contract;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;

namespace Freelancers.Domain.Interfaces.Contract;

public interface IAcceptTermsOfContractUseCase
{
    Task<BaseResponse<ResponseContractDTO>> Execute(RequestContractStatusDTO request);
}
