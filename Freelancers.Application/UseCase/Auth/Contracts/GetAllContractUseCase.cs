using AutoMapper;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Contract;
using Freelancers.Domain.Interfaces.Contract;
using Freelancers.Domain.Repositories.Contracts;

namespace Freelancers.Application.UseCase.Auth.Contracts;

public class GetAllContractUseCase(IContractReadOnlyRepository contractReadOnlyRepository, IMapper mapper) : IGetAllContratcsUseCase
{
    private readonly IContractReadOnlyRepository _contractReadOnlyRepository = contractReadOnlyRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<BasePagedResponse<List<ResponseContractDTO>?>> Execute(int userID, int pageSize, int pageNumber)
    {
        var contract = await _contractReadOnlyRepository.GetAllAsync(userID, pageSize, pageNumber);

        if (contract is null)
            return new BasePagedResponse<List<ResponseContractDTO>?>([], "Nenhum contrato encontrado");

        var contractData = _mapper.Map<List<ResponseContractDTO>>(contract.Data);

        var contratcDTO = new BasePagedResponse<List<ResponseContractDTO>?>(
            contractData,
            contract!.TotalCount,
            pageNumber,
            pageSize);

        return contratcDTO;
    }
}
