﻿
using System.Net;

namespace Freelancers.Domain.Exceptions;

public class ErrorOnValidationException(List<string> errorMessages) : FreelancersException(string.Empty)
{
    private readonly List<string> _errors = errorMessages;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return _errors;
    }
}
