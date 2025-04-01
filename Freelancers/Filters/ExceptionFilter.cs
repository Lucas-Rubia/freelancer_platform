using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Freelancers.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FreelancersException)
            HandleProjectException(context);
        else
            ThrowUnknowError(context);
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        var freelancersException = (FreelancersException)context.Exception;
        var errorResponse = new ResponseErrorDTO(freelancersException.GetErrors());

        context.HttpContext.Response.StatusCode = freelancersException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private static void ThrowUnknowError(ExceptionContext context) 
    {
        var errorResponse = new ResponseErrorDTO($"Houve um erro Desconhecido!{context.Exception.Message}");
        
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
