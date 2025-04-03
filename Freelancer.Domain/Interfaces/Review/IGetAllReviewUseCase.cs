using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Review;
using Freelancers.Domain.DTOs.Responses.User;

namespace Freelancers.Domain.Interfaces.Review;

public interface IGetAllReviewUseCase
{
    Task<BaseResponse<List<ResponseReviewDTO>?>> Execute();
}
