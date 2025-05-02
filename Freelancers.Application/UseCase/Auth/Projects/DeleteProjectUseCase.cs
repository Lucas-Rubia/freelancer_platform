using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Projects;

namespace Freelancers.Application.UseCase.Auth.Projects;

public class DeleteProjectUseCase(IProjectWriteOnlyRepository projectWriteOnlyRepository, IUnityOfWork unityOfWork) : IDeleteProjectUseCase
{
    private readonly IProjectWriteOnlyRepository _projectWriteOnlyRepository = projectWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;

    public async Task Execute(int projectId)
    {
        var project = await _projectWriteOnlyRepository.Delete(projectId);

        if (project == false)
            throw new NotFoundException("Projeto não encontrado");

        await _unityOfWork.Commit();
    }
}
