using Freelancers.Domain.DTOs.Requests.Review;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Review;

namespace Freelancers.Domain.Interfaces.Review;

public interface ICreateReviewCase
{
    Task<BaseResponse<ResponseCreateReviewDTO>> Execute(RequestReviewDTO request);
}
