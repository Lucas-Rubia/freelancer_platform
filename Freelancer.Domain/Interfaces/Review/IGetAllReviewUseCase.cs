using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Review;
using Freelancers.Domain.DTOs.Responses.User;

namespace Freelancers.Domain.Interfaces.Review;

public interface IGetAllReviewUseCase
{
    Task<BasePagedResponse<List<ResponseReviewDTO>?>> Execute(int pageSize, int PageNumber);
}
