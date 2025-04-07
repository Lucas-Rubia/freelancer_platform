using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Reviwers;

public interface IReviewReadOnlyRepository
{
    Task<BasePagedResult<List<Review>?>> GetAllAsync(int pageSize, int pageResult);
}
