using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.Interfaces.Proposal;
using Microsoft.AspNetCore.Mvc;

namespace Freelancers.Controllers.Proposals;

[Route("api/[controller]")]
[ApiController]
public class ProposalController : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> CreateProposal([FromServices] ICreateProposalCase useProposal, [FromBody] RequestProposalDTO request)
    {
        var response = await useProposal.Execute(request);
        return Created(string.Empty, response);
    }
}