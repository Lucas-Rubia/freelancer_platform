using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Users;

public interface IUserReadOnlyRepository
{
    Task<List<User>?> GetAllAsync();
}
