using Freelancers.Domain;
using Freelancers.Domain.DTOs.Requests.Contract;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;
using Freelancers.Domain.Interfaces.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Freelancers.Controllers.Contracts;

[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<ResponseContractDTO>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateContract([FromServices] ICreateContractUseCase useContract, [FromBody] RequestCreateContractDTO request)
    {
        var response = await useContract.Execute(request);
        return Created(string.Empty, response);
    }


    [HttpGet("{userID}")]
    [ProducesResponseType(typeof(BaseResponse<ResponseContractDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllContract(
        [FromServices] IGetAllContratcsUseCase useContract,
        [FromRoute] int userID,
        [FromQuery] int pageSize = APIConfiguration.DefaultPageSize,
        [FromQuery] int pageNumber = APIConfiguration.DefaultPageNumber)
    {
        var response = await useContract.Execute(userID, pageSize, pageNumber);
        return Ok(response);
    }


    [HttpPatch]

    [ProducesResponseType(typeof(BaseResponse<ResponseContractDTO>), StatusCodes.Status200OK)]

    public async Task<IActionResult> AcceptTermsOfContract(
        [FromServices] IAcceptTermsOfContractUseCase useContract,
        [FromBody] RequestContractStatusDTO request)
    {
        var response = await useContract.Execute(request);
        return Ok(response);
    }
}
