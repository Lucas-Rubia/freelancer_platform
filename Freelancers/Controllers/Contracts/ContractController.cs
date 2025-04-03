using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Interfaces.Contract;
using Microsoft.AspNetCore.Mvc;
using Freelancers.Domain.DTOs.Responses.Contract;

namespace Freelancers.Controllers.Contracts;

[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    [HttpGet]

    [ProducesResponseType(typeof(ResponseContractDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllContract([FromServices] IGetAllContratcsUseCase useContract)
    {
        var response = await useContract.Execute();
        return Ok(response);
    }
}
