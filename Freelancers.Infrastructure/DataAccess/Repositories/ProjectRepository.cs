using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Enums;
using Freelancers.Domain.Repositories.Projects;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class ProjectRepository(FreelancersDbContext context) : IProjectWriteOnlyRepository, IProjectReadOnlyRepository
{
    private readonly FreelancersDbContext _dbcontext = context;

    public async Task Add(Project project)
    {
        await _dbcontext.Projects.AddAsync(project);
    }

    public async Task<bool> Delete(int projectId)
    {
        var result = await _dbcontext
            .Projects
            .FirstOrDefaultAsync(x => x.Id == projectId);

        if (result == null)
            return false;

        _dbcontext.Remove(result);
        return true;
    }

    public async Task<BasePagedResult<List<Project>?>> GetAllAsync(int userID, int pageSize, int pageNumber)
    {
        var query = _dbcontext
            .Projects
            .AsNoTracking()
            .Where(x => x.UserId == userID || x.Proposals.Any(y => y.FreelancerId == userID && y.Status == EBaseStatus.Accept))
            .OrderBy(x => x.Title);

        var projects = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new BasePagedResult<List<Project>?>(projects, count);
    }

    public async Task<Project?> GetByIdAsync(int projectId)
    {
        return await _dbcontext
            .Projects
            .FirstOrDefaultAsync(x => x.Id == projectId);
    }

    public void UpdateProjectInformation(Project project)
    {
        _dbcontext.Projects.Update(project);
    }
}
