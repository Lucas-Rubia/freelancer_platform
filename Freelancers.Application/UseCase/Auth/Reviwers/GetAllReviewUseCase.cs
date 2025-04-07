using AutoMapper;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Review;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Interfaces.Review;
using Freelancers.Domain.Repositories.Reviwers;

namespace Freelancers.Application.UseCase.Auth.Reviwers;

public class GetAllReviewUseCase(IReviewReadOnlyRepository reviewReadOnlyRepository, IMapper mapper) : IGetAllReviewUseCase
{
    private readonly IReviewReadOnlyRepository _reviewReadOnlyRepository = reviewReadOnlyRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<BasePagedResponse<List<ResponseReviewDTO>?>> Execute(int pageSize, int pageNumber)
    {
        var reviwer = await _reviewReadOnlyRepository.GetAllAsync(pageSize, pageNumber);

        if (reviwer is null)
            return new BasePagedResponse<List<ResponseReviewDTO>?>([], "Reviw não encontrado ou não cadastrada");

        var reviweData = _mapper.Map<List<ResponseReviewDTO>>(reviwer.Data);

        var reviewDTO = new BasePagedResponse<List<ResponseReviewDTO>?>(
            reviweData,
            reviwer!.TotalCount,
            pageSize,
            pageNumber);

        return reviewDTO;
    }
}
