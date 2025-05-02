using AutoMapper;
using Freelancers.Domain.DTOs.Requests.Proposal;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Proposals;

namespace Freelancers.Application.UseCase.Auth.Proposals;

public class ProcessProposalStatusUseCase(IProposalReadOnlyRepository proposalReadOnlyRepository,
    IProposalWriteOnlyRepository proposalWriteOnlyRepository,
    IMapper mapper,
    IUnityOfWork unityOfWork) : IProcessProposalStatusUseCase
{
    private readonly IProposalReadOnlyRepository _proposalReadOnlyRepository = proposalReadOnlyRepository;
    private readonly IProposalWriteOnlyRepository _proposalWriteOnlyRepository = proposalWriteOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;

    public async Task<BaseResponse<ResponseProposalStatusDTO>> Execute(RequestProposalStatusDTO request)
    {
        var proposal = await _proposalReadOnlyRepository.GetByIdAsync(request.ProposalID);

        if (proposal is null)
            return new BaseResponse<ResponseProposalStatusDTO>(null, "Proposta não encontrada");

        proposal.Status = request.Status;
        proposal.UpdatedAt = DateTime.UtcNow;

        _proposalWriteOnlyRepository.UpdateProposalStatus(proposal);

        await _unityOfWork.Commit();

        var proposalData = _mapper.Map<ResponseProposalStatusDTO>(proposal);

        return new BaseResponse<ResponseProposalStatusDTO>(proposalData);
    }
}
