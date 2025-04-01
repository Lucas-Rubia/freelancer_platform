using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories;

public interface IProjectWriteOnlyRepository
{
    Task Add(Project project);
}
