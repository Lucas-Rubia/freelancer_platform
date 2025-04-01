﻿using System.Net;

namespace Freelancers.Domain.Exceptions;

public class DomainException(string message) : FreelancersException(message)
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
