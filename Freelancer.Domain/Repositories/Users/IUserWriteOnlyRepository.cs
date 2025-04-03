using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Users;

public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
