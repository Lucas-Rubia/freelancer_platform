using System.Diagnostics.Contracts;
using AutoMapper;
using Freelancers.Domain.DTOs.Requests.Project;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;
using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Projects;

namespace Freelancers.Application.UseCase.Auth.Projects;

public class CreateProjectUseCase(
    IProjectWriteOnlyRepository projectWriteOnlyRepository,
    IUnityOfWork unityOfWork, 
    IMapper mapper) : ICreateProjectCase
{
    private readonly IProjectWriteOnlyRepository _projectWriteOnlyRepository = projectWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<BaseResponse<ResponseCreateProjectDTO>> Execute(RequestProjectDTO request)
    {
        await Validate(request);

        var project = Project.Create(request.Title, request.Description, request.DeadLine, request.Bugdet, request.UserId);

        await _projectWriteOnlyRepository.Add(project);
        await _unityOfWork.Commit();

        var projectData = _mapper.Map<ResponseCreateProjectDTO>(project);

        return new BaseResponse<ResponseCreateProjectDTO>(projectData);

    }

    private static async Task Validate(RequestProjectDTO request)
    {
        var result = await new CreateProjectValidator().ValidateAsync(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
