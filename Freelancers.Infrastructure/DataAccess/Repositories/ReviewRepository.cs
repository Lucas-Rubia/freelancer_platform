using Freelancers.Domain.DTOs.Responses;
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

    public async Task<BasePagedResult<List<Review>?>> GetAllAsync(int pageSize, int pageNumber)
    {
        var query = _dbcontext
            .Reviews
            .AsNoTracking();

        var reviwer = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new BasePagedResult<List<Review>?>(reviwer, count);
    }
}