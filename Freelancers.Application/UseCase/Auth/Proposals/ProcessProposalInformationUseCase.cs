using Freelancers.Domain.Repositories.Proposals;
using Freelancers.Domain.Repositories;
using AutoMapper;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.DTOs.Requests.Proposal;

namespace Freelancers.Application.UseCase.Auth.Proposals;

public class ProcessProposalInformationUseCase(
    IProposalReadOnlyRepository proposalReadOnlyRepository,
    IProposalWriteOnlyRepository proposalWriteOnlyRepository,
    IMapper mapper,
    IUnityOfWork unityOfWork) : IProcessProposalInformationUseCase
{

    private readonly IProposalReadOnlyRepository _proposalReadOnlyRepository = proposalReadOnlyRepository;
    private readonly IProposalWriteOnlyRepository _proposalWriteOnlyRepository = proposalWriteOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    public async Task<BaseResponse<ResponseProposalInformationDTO>> Execute(RequestProposalInformationDTO request)
    {
        var proposal = await _proposalReadOnlyRepository.GetByIdAsync(request.ProposalID);

        if (proposal is null)
            return new BaseResponse<ResponseProposalInformationDTO>(null, "Proposta não encontrada");

        proposal.ProposedValue = request.ProposedValue;
        proposal.Message = request.Message;
        proposal.UpdatedAt = DateTime.UtcNow;

        _proposalWriteOnlyRepository.UpdateProposalStatus(proposal);

        await _unityOfWork.Commit();

        var proposalData = _mapper.Map<ResponseProposalInformationDTO>(proposal);

        return new BaseResponse<ResponseProposalInformationDTO>(proposalData);
    }
}
