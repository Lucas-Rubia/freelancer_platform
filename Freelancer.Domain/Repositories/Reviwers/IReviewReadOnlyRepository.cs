using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Reviwers;

public interface IReviewReadOnlyRepository
{
    Task<List<Review>?> GetAllAsync();
}
