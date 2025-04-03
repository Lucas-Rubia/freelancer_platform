using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;
using Freelancers.Domain.Interfaces.Contract;
using Freelancers.Domain.Repositories.Contracts;

namespace Freelancers.Application.UseCase.Auth.Contracts;

public class GetAllContractUseCase(IContractReadOnlyRepository contractReadOnlyRepository) : IGetAllContratcsUseCase
{
    private readonly IContractReadOnlyRepository _contractReadOnlyRepository = contractReadOnlyRepository;
    public async Task<BaseResponse<List<ResponseContractDTO>?>> Execute()
    {
        var contract = await _contractReadOnlyRepository.GetAllAsync();

        if (contract is null)
            return new BaseResponse<List<ResponseContractDTO>?>([], "Nenhum contrato encontrado");

        var contractData = contract?.Select(x => new ResponseContractDTO
        {
            Id = x.Id,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            Status = x.Status

        }).ToList();

        var contratcDTO = new BaseResponse<List<ResponseContractDTO>?>(contractData, "Contrato encontrado com sucesso");

        return contratcDTO;
    }
}
