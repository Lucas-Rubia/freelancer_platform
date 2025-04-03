using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories.Projects;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class ProjectRepository(FreelancersDbContext context) : IProjectWriteOnlyRepository, IProjectReadOnlyRepository
{
    private readonly FreelancersDbContext _dbconxtext = context;

    public async Task Add(Project project)
    {
        await _dbconxtext.Projects.AddAsync(project);
    }

    public async Task<List<Project>?> GetAllAsync()
    {
        return await _dbconxtext.Projects.AsNoTracking().ToListAsync();
    }
}
