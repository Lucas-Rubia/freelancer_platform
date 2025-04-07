using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Contracts;

public interface IContractReadOnlyRepository
{
    Task<BasePagedResult<List<Contract>?>> GetAllAsync(int pageSize, int pageNumber);
}
