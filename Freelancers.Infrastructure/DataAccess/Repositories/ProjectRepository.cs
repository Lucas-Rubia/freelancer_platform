using Freelancers.Domain.DTOs.Responses;
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

    public async Task<BasePagedResult<List<Project>?>> GetAllAsync(int pageSize, int pageNumber)
    {
        var query = _dbconxtext
            .Projects
            .AsNoTracking()
            .OrderBy(x => x.Title);

        var projects = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new BasePagedResult<List<Project>?>(projects, count);
    }
}
