namespace Freelancers.Domain.Repositories;

public interface IUnityOfWork
{
    Task Commit();
}
