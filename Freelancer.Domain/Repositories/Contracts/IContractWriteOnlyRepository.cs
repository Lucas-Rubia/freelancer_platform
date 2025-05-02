using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Contracts;

public interface IContractWriteOnlyRepository
{
    Task Add(Contract contract);
    void UpdateContractStatus(Contract contract);
}
