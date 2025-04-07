using AutoMapper;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.Repositories.Proposals;

namespace Freelancers.Application.UseCase.Auth.Proposals;

internal class GetAllProposalUseCase(IProposalReadOnlyRepository proposalReadOnlyRepository, IMapper mapper) : IGetAllProposalUseCase
{
    private readonly IProposalReadOnlyRepository _proposalReadOnlyRepository = proposalReadOnlyRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<BasePagedResponse<List<ResponseProposalDTO>?>> Execute(int pageSize, int pageNumber)
    {
        var proposal = await _proposalReadOnlyRepository.GetAllAsync(pageSize, pageNumber);

        if (proposal is null)
            return new BasePagedResponse<List<ResponseProposalDTO>?>([], "Não foi encontrado nenhuma proposta");

        var proposalData = _mapper.Map<List<ResponseProposalDTO>>(proposal.Data);

        var proposalDTO = new BasePagedResponse<List<ResponseProposalDTO>?>(
            proposalData,
            proposal!.TotalCount,
            pageNumber,
            pageSize);

        return proposalDTO;
    }
}
