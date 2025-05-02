
using System.Net;

namespace Freelancers.Domain.Exceptions;

public class NotFoundException(string message) : FreelancersException(message)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
