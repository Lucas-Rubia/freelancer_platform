using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Projects;

public interface IProjectWriteOnlyRepository
{
    Task Add(Project project);
}
