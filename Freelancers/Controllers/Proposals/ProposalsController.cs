using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Interfaces.Proposal;
using Microsoft.AspNetCore.Mvc;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Entities;
using Freelancers.Domain.DTOs.Requests.Proposal;

namespace Freelancers.Controllers.Proposals;

[Route("api/[controller]")]
[ApiController]
public class ProposalController : ControllerBase
{
    [HttpPost]

    [ProducesResponseType(typeof(ResponseCreatedProposalDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProposal([FromServices] ICreateProposalCase useProposal, [FromBody] RequestProposalDTO request)
    {
        var response = await useProposal.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet("{userID}")]

    [ProducesResponseType(typeof(ResponseCreatedProposalDTO), StatusCodes.Status200OK)]

    public async Task<IActionResult> GetAllProposal(
        [FromServices] IGetAllProposalUseCase useProposal,
        [FromRoute] int userID,
        [FromQuery] int pageSize = APIConfiguration.DefaultPageSize,
        [FromQuery] int pageNumber = APIConfiguration.DefaultPageNumber)
    {
        var response = await useProposal.Execute(userID, pageSize, pageNumber);
        return Ok(response);
    }

    [HttpPatch]

    [ProducesResponseType(typeof(BaseResponse<ResponseProposalStatusDTO>), StatusCodes.Status200OK)]

    public async Task<IActionResult> ProcessProposalStatus(
        [FromServices] IProcessProposalStatusUseCase useProposal,
        [FromBody] RequestProposalStatusDTO request)
    {
        var response = await useProposal.Execute(request);
        return Ok(response);
    }

    [HttpPatch("Information")]

    [ProducesResponseType(typeof(BaseResponse<ResponseProposalInformationDTO>), StatusCodes.Status200OK)]

    public async Task<IActionResult> ProcessProposalInformation(
    [FromServices] IProcessProposalInformationUseCase useProposal,
    [FromBody] RequestProposalInformationDTO request)
    {
        var response = await useProposal.Execute(request);
        return Ok(response);
    }


    [HttpDelete(("{proposalID}"))]

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProposal(
    [FromServices] IDeleteProposalUseCase useProposal,
    [FromRoute] int proposalID)
    {
        await useProposal.Execute(proposalID);
        return NoContent();
    }
}