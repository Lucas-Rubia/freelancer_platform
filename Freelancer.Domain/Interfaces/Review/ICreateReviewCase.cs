using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses.Review;

namespace Freelancers.Domain.Interfaces.Review;

public interface ICreateReviewCase
{
    Task<ResponseCreateReviewDTO> Execute(RequestReviewDTO request);
}
