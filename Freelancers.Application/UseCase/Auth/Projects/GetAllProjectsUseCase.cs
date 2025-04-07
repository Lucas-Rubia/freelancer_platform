    using AutoMapper;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Repositories.Projects;

namespace Freelancers.Application.UseCase.Auth.Projects;

public class GetAllProjectsUseCase(IProjectReadOnlyRepository projectReadOnlyRepository, IMapper mapper) : IGetAllProjectsUseCase
{
    private readonly IProjectReadOnlyRepository _projectReadOnlyRepository = projectReadOnlyRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<BasePagedResponse<List<ResponseProjectsDTO>?>> Execute(int pageSize, int pageNumber)
    {
        var projects = await _projectReadOnlyRepository.GetAllAsync(pageSize, pageNumber);

        if(projects is null)
            return new BasePagedResponse<List<ResponseProjectsDTO>?>([], "Projects não coletados");

        var projectsData = _mapper.Map<List<ResponseProjectsDTO>>(projects.Data);

        return new BasePagedResponse<List<ResponseProjectsDTO>?>(
            projectsData,
            projects!.TotalCount,
            pageNumber,
            pageSize);
    }
}
