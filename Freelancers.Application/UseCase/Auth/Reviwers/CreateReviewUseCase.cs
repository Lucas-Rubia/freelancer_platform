﻿using AutoMapper;
using Freelancers.Domain.DTOs.Requests.Review;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Review;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Interfaces.Review;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Reviwers;

namespace Freelancers.Application.UseCase.Auth.Reviwers;

public class CreateReviewUseCase (IReviewWriteOnlyRepository reviewWriteOnlyRepository, IUnityOfWork unityOfWork, IMapper mapper) : ICreateReviewCase
{

    private readonly IReviewWriteOnlyRepository _reviewWriteOnlyRepository = reviewWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<ResponseCreateReviewDTO>> Execute(RequestReviewDTO request)
    {
        await Validate(request);

        var reviewer = Review.Create(request.ContractID ,request.Rating, request.Comment);

        await _reviewWriteOnlyRepository.Add(reviewer);
        await _unityOfWork.Commit();

        var reviewerData = _mapper.Map<ResponseCreateReviewDTO>(reviewer);
        
        return new BaseResponse<ResponseCreateReviewDTO>(reviewerData);
    }

    private static async Task Validate(RequestReviewDTO request)
    {
        var result = await new CreateReviewValidator().ValidateAsync(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
