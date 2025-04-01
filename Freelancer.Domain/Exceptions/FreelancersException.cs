namespace Freelancers.Domain.Exceptions;

public abstract class FreelancersException : SystemException
{
    protected FreelancersException(string message) : base(message) { }

    public abstract int StatusCode { get; }

    public abstract List<string> GetErrors();
}
