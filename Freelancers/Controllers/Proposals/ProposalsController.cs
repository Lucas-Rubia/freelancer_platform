using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Interfaces.Proposal;
using Microsoft.AspNetCore.Mvc;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain;

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

    [HttpGet]

    [ProducesResponseType(typeof(ResponseCreatedProposalDTO), StatusCodes.Status200OK)]

    public async Task<IActionResult> GetAllProposal([FromServices] IGetAllProposalUseCase useProposal, 
        [FromQuery] int pageSize = APIConfiguration.DefaultPageSize, int pageNumber = APIConfiguration.DefaultPageNumber)
    {
        var response = await useProposal.Execute(pageSize, pageNumber);
        return Ok(response);
    }
}