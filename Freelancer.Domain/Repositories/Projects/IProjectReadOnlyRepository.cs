using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Projects;

public interface IProjectReadOnlyRepository
{
    Task<List<Project>?> GetAllAsync();
}
