using Freelancers.Domain;
using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Review;
using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.Interfaces.Review;
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

    [HttpGet]

    [ProducesResponseType(typeof(ResponseCreatedUserDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllUsers([FromServices] IGetAllUserUseCase useUser,
        [FromQuery] int pageSize = APIConfiguration.DefaultPageSize, int pageNumber = APIConfiguration.DefaultPageNumber)
    {
        var response = await useUser.Execute(pageSize, pageNumber);
        return Ok(response);
    }
}
