using Freelancers.Domain;
using Freelancers.Domain.DTOs.Requests.Project;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Interfaces.Proposal;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("{userID}")]

    [ProducesResponseType(typeof(BasePagedResponse<List<ResponseProjectsDTO>?>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProject(
        [FromServices] IGetAllProjectsUseCase useProject,
        [FromRoute] int userID,
        [FromQuery] int pageSize = APIConfiguration.DefaultPageSize,
        [FromQuery] int pageNumber = APIConfiguration.DefaultPageNumber)
    {
        var response = await useProject.Execute(userID, pageSize, pageNumber);

        return Ok(response);


        //if (response is not null && response.Data?.Count != 0)
        //    return Ok(response);

        //return NoContent();
    }



    [HttpPatch("Information")]

    [ProducesResponseType(typeof(BaseResponse<ResponseProjectInformationDTO>), StatusCodes.Status200OK)]

    public async Task<IActionResult> ProcessProjectInformation(
    [FromServices] IProcessProjectInformationUseCase useProject,
    [FromBody] RequestProjectInformationDTO request)
    {
        var response = await useProject.Execute(request);
        return Ok(response);
    }


    [HttpDelete(("{projectID}"))]

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProject(
        [FromServices] IDeleteProjectUseCase useProject,
        [FromRoute] int projectID)
    {
        await useProject.Execute(projectID);
        return NoContent();
    }
}