using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class ProjectRepository(FreelancersDbContext context) : IProjectWriteOnlyRepository, IProjectReadOnlyRepository
{
    private readonly FreelancersDbContext _dbconxtext = context;

    public async Task Add(Project project)
    {
        await _dbconxtext.Projects.AddAsync(project);
    }
}
