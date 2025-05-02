using AutoMapper;
using Freelancers.Domain.DTOs.Requests.Contract;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Interfaces.Contract;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Contracts;

namespace Freelancers.Application.UseCase.Auth.Contracts;

public class AcceptTermsOfContractUseCase(IContractReadOnlyRepository contractReadOnlyRepository,
    IContractWriteOnlyRepository contractWriteOnlyRepository,
    IMapper mapper,
    IUnityOfWork unityOfWork): IAcceptTermsOfContractUseCase
{
    private readonly IContractReadOnlyRepository _contractReadOnlyRepository = contractReadOnlyRepository;
    private readonly IContractWriteOnlyRepository _contractWriteOnlyRepository = contractWriteOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;

    public async Task<BaseResponse<ResponseContractDTO>> Execute(RequestContractStatusDTO request)
    {
        await Validate(request);

        var contract = await _contractReadOnlyRepository.GetByIdAsync(request.ContractID);

        if (contract is null)
            return new BaseResponse<ResponseContractDTO>(null, "Contrato não encontrado");

        contract.Status = request.Status;
        contract.UpdatedAt = DateTime.UtcNow;

        _contractWriteOnlyRepository.UpdateContractStatus(contract);

        await _unityOfWork.Commit();

        var contractData = _mapper.Map<ResponseContractDTO>(contract);

        return new BaseResponse<ResponseContractDTO>(contractData);
    }

    private static async Task Validate(RequestContractStatusDTO request)
    {
        var result = await new UpdateContractStatusValidator().ValidateAsync(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
