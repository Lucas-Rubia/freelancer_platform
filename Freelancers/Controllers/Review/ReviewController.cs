using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Review;
using Freelancers.Domain.Interfaces.Review;
using Microsoft.AspNetCore.Mvc;

namespace Freelancers.Controllers.Proposals;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    [HttpPost]

    [ProducesResponseType(typeof(ResponseCreateReviewDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateReview([FromServices] ICreateReviewCase useReview, [FromBody] RequestReviewDTO request)
    {
        var response = await useReview.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]

    [ProducesResponseType(typeof(ResponseCreateReviewDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorDTO), StatusCodes.Status404NotFound)]

    public async Task<IActionResult> GetAllReview([FromServices] IGetAllReviewUseCase useReview)
    {
        var response = await useReview.Execute();
        return Ok(response);
    }
}
