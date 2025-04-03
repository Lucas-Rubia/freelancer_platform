using Freelancers.Domain.Entities;

namespace Freelancers.Domain.Repositories.Reviwers;

public interface IReviewWriteOnlyRepository
{
    Task Add(Review review);
}
