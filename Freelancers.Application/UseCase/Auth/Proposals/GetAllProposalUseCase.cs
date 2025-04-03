using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.Repositories.Proposals;

namespace Freelancers.Application.UseCase.Auth.Proposals;

internal class GetAllProposalUseCase(IProposalReadOnlyRepository proposalReadOnlyRepository) : IGetAllProposalUseCase
{
    private readonly IProposalReadOnlyRepository _proposalReadOnlyRepository = proposalReadOnlyRepository;
    public async Task<BaseResponse<List<ResponseProposalDTO>?>> Execute()
    {
        var proposal = await _proposalReadOnlyRepository.GetAllAsync();

        if (proposal is null)
            return new BaseResponse<List<ResponseProposalDTO>?>([], "Não foi encontrado nenhuma proposta");

        var proposalData = proposal?.Select(x => new ResponseProposalDTO{
            Id = x.Id,
            Message = x.Message,
            ProposedValue = x.ProposedValue,
        }).ToList();

        var proposalDTO = new BaseResponse<List<ResponseProposalDTO>?>(proposalData, "Propostas achadas com sucesso");

        return proposalDTO;
    }
}
