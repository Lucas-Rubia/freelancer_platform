using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Review;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Interfaces.Review;
using Freelancers.Domain.Repositories.Reviwers;

namespace Freelancers.Application.UseCase.Auth.Reviwers;

public class GetAllReviewUseCase(IReviewReadOnlyRepository reviewReadOnlyRepository) : IGetAllReviewUseCase
{
    private readonly IReviewReadOnlyRepository _reviewReadOnlyRepository = reviewReadOnlyRepository;

    public async Task<BaseResponse<List<ResponseReviewDTO>?>> Execute()
    {
        var reviwer = await _reviewReadOnlyRepository.GetAllAsync();

        if (reviwer is null)
            return new BaseResponse<List<ResponseReviewDTO>?>([], "Reviw não encontrado ou não cadastrada");

        var reviweData = reviwer?.Select(x => new ResponseReviewDTO
        {
            Id = x.Id,
            Comment = x.Comment,
            Rating = x.Rating
        }).ToList();

        var reviewDTO = new BaseResponse<List<ResponseReviewDTO>?>(reviweData, "Reviw encontrado com sucesso");

        return reviewDTO;
    }
}
