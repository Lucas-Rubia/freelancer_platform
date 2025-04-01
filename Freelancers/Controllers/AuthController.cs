using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Interfaces.Proposal;
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

    [HttpPost("CreateProject")]
    public async Task<IActionResult> CreateProject([FromServices] ICreateProjectCase useProject, [FromBody] RequestProjectDTO request)
    {
        var response = await useProject.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpPost("CreateProposal")]

    public async Task<IActionResult> CreateProposal([FromServices] ICreateProposalCase useProposal, [FromBody] RequestProposalDTO request)
    {
        var response = await useProposal.Execute(request);
        return Created(string.Empty, response);
    }
}
