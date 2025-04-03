using Freelancers.Domain.Entities;
using Freelancers.Domain.Repositories.Reviwers;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Infrastructure.DataAccess.Repositories;

internal class ReviewRepository(FreelancersDbContext context) : IReviewWriteOnlyRepository, IReviewReadOnlyRepository
{
    private readonly FreelancersDbContext _dbcontext = context;
    public async Task Add(Review review)
    {
        await _dbcontext.Reviews.AddAsync(review);
    }

    public async Task<List<Review>?> GetAllAsync()
    {
        return await _dbcontext.Reviews.AsNoTracking().ToListAsync();
    }
}