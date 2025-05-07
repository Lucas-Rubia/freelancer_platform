using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;

namespace Freelancers.Domain.Interfaces.Contract;

public interface IGetAllContratcsUseCase
{
    Task<BasePagedResponse<List<ContractWithTitleAndSubcriptionProject>?>> Execute(int userID, int pageSize, int pageNumber);
}
