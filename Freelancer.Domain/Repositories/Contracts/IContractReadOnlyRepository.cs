using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Contracts;

public interface IContractReadOnlyRepository
{
    Task<List<Contract>?> GetAllAsync();
}
