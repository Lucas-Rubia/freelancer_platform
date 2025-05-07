using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Contracts;

public interface IContractReadOnlyRepository
{
    Task<BasePagedResult<List<ContractWithTitleAndSubcriptionProject>?>> GetAllAsync(int userID, int pageSize, int pageNumber);

    Task<Contract?> GetByIdAsync(int contractId);
}
