using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Interfaces.Project;
using Microsoft.AspNetCore.Mvc;
using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain;

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

    [ProducesResponseType(typeof(BasePagedResponse<List<ResponseProjectsDTO>?>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProject(
        [FromServices] IGetAllProjectsUseCase useProject,
        [FromQuery] int pageSize = APIConfiguration.DefaultPageSize, 
        int pageNumber = APIConfiguration.DefaultPageNumber)
    {
        var response = await useProject.Execute(pageSize, pageNumber);

        return Ok(response);


        //if (response is not null && response.Data?.Count != 0)
        //    return Ok(response);

        //return NoContent();
    }
}