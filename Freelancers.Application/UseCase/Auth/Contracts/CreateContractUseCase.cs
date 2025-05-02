using AutoMapper;
using Freelancers.Application.UseCase.Auth.Projects;
using Freelancers.Domain.DTOs.Requests.Contract;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Interfaces.Contract;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Contracts;

namespace Freelancers.Application.UseCase.Auth.Contracts;

public class CreateContractUseCase(IContractWriteOnlyRepository contractWriteOnlyRepository, IUnityOfWork unityOfWork, IMapper mapper) : ICreateContractUseCase
{
    private readonly IContractWriteOnlyRepository _contractWriteOnlyRepository = contractWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IMapper _mapper = mapper;


    public async Task<BaseResponse<ResponseContractDTO>> Execute(RequestCreateContractDTO request)
    {
        await Validate(request);

        var contract = Contract.Create(request.ProposalID, request.StartDate, request.EndDate);
        await _contractWriteOnlyRepository.Add(contract);
        await _unityOfWork.Commit();

        var contractData = _mapper.Map<ResponseContractDTO>(contract);

        return new BaseResponse<ResponseContractDTO>(contractData);

    }
    private static async Task Validate(RequestCreateContractDTO request)
    {
        var result = await new CreateContractValidator().ValidateAsync(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
