using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Contracts;

public interface IContractReadOnlyRepository
{
    Task<BasePagedResult<List<Contract>?>> GetAllAsync(int userID, int pageSize, int pageNumber);

    Task<Contract?> GetByIdAsync(int contractId);
}
