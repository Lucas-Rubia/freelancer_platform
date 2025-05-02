using AutoMapper;
using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Projects;
using Freelancers.Domain.DTOs.Requests.Project;

namespace Freelancers.Application.UseCase.Auth.Projects;

public class ProcessProjectInformationUseCase(IProjectReadOnlyRepository projectReadOnlyRepository,
    IProjectWriteOnlyRepository projectWriteOnlyRepository,
    IMapper mapper,
    IUnityOfWork unityOfWork) : IProcessProjectInformationUseCase
{
    private readonly IProjectReadOnlyRepository _projectReadOnlyRepository = projectReadOnlyRepository;
    private readonly IProjectWriteOnlyRepository _projectWriteOnlyRepository = projectWriteOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;


    public async Task<BaseResponse<ResponseProjectInformationDTO>> Execute(RequestProjectInformationDTO request)
    {

        var project = await _projectReadOnlyRepository.GetByIdAsync(request.ProjectID);

        if (project is null)
            return new BaseResponse<ResponseProjectInformationDTO>(null, "Projeto não encontrado");

        project.Title = request.Title;
        project.Description = request.Description;
        project.UpdatedAt = DateTime.UtcNow;

        _projectWriteOnlyRepository.UpdateProjectInformation(project);

        await _unityOfWork.Commit();

        var projectData = _mapper.Map<ResponseProjectInformationDTO>(project);

        return new BaseResponse<ResponseProjectInformationDTO>(projectData);
    }
}


