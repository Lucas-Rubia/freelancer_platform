using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Interfaces.Project;
using Microsoft.AspNetCore.Mvc;
using Freelancers.Domain.DTOs.Responses.Projects;

namespace Freelancers.Controllers.Projects;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    [HttpPost]

    [ProducesResponseType(typeof(ResponseCreateProjectDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProject([FromServices] ICreateProjectCase useProject, [FromBody] RequestProjectDTO request)
    {
        var response = await useProject.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]

    [ProducesResponseType(typeof(ResponseCreateProjectDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllProject([FromServices] IGetAllProjectsUseCase useProject)
    {
        var response = await useProject.Execute();
        return Ok(response);
    }

}