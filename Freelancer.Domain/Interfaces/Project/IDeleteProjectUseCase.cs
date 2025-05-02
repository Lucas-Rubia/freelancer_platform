namespace Freelancers.Domain.Interfaces.Project;

public interface IDeleteProjectUseCase
{
    Task Execute(int projectId);
}
