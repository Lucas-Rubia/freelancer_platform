using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace Freelancers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedUserDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status400BadRequest)]

    
    public async Task<IActionResult> CreateUser([FromServices] ICreateUserUseCase useCase, [FromBody] RequestUserDTO request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }
}
