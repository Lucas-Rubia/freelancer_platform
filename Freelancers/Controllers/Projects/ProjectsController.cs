using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.Interfaces.Project;
using Microsoft.AspNetCore.Mvc;

namespace Freelancers.Controllers.Projects;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> CreateProject([FromServices] ICreateProjectCase useProject, [FromBody] RequestProjectDTO request)
    {
        var response = await useProject.Execute(request);
        return Created(string.Empty, response);
    }
}