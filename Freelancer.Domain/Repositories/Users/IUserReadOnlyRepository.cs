using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Users;

public interface IUserReadOnlyRepository
{
    Task<BasePagedResult<List<User>?>> GetAllAsync(int pageSize, int pageNumber);
}
