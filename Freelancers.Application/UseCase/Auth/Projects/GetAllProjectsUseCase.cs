using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Repositories.Projects;

namespace Freelancers.Application.UseCase.Auth.Projects;

public class GetAllProjectsUseCase(IProjectReadOnlyRepository projectReadOnlyRepository) : IGetAllProjectsUseCase
{
    private readonly IProjectReadOnlyRepository _projectReadOnlyRepository = projectReadOnlyRepository;

    public async Task<BaseResponse<List<ResponseProjectsDTO>?>> Execute()
    {
        var projects = await _projectReadOnlyRepository.GetAllAsync();

        if(projects is null)
            return new BaseResponse<List<ResponseProjectsDTO>?>([], "Projects não coletados");

        var projectsData = projects?.Select(x => new ResponseProjectsDTO
        {
            Id = x.Id,
            Bugdet = x.Bugdet,
            DeadLine = x.DeadLine,
            Title = x.Title
        }).ToList();

        var projectsDTO = new BaseResponse<List<ResponseProjectsDTO>?>(projectsData, "Projects coletados com sucesso");

        return projectsDTO;

    }
}
