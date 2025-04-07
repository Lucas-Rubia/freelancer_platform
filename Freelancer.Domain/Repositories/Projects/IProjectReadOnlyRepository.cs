using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Projects;

public interface IProjectReadOnlyRepository
{
    Task<BasePagedResult<List<Project>?>> GetAllAsync(int pageSize, int pageNumber);
}
