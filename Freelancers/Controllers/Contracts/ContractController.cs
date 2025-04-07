using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Interfaces.Contract;
using Microsoft.AspNetCore.Mvc;
using Freelancers.Domain.DTOs.Responses.Contract;
using Freelancers.Domain;

namespace Freelancers.Controllers.Contracts;

[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    [HttpGet]

    [ProducesResponseType(typeof(ResponseContractDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllContract([FromServices] IGetAllContratcsUseCase useContract,
        [FromQuery] int pageSize = APIConfiguration.DefaultPageSize, int pageNumber = APIConfiguration.DefaultPageNumber)
    {
        var response = await useContract.Execute(pageSize, pageNumber);
        return Ok(response);
    }
}
