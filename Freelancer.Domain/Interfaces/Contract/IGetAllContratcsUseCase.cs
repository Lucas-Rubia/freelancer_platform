using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;

namespace Freelancers.Domain.Interfaces.Contract;

public interface IGetAllContratcsUseCase
{
    Task<BaseResponse<List<ResponseContractDTO>?>> Execute();
}
