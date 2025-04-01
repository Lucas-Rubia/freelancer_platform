using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories;

public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
