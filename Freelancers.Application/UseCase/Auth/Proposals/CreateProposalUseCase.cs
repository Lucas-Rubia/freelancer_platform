using AutoMapper;
using Freelancers.Domain.DTOs.Requests.Proposal;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Proposals;

namespace Freelancers.Application.UseCase.Auth.Proposals;

public class CreateProposalUseCase(IProposalWriteOnlyRepository proposalWriteOnlyRepository, IUnityOfWork unityOfWork, IMapper mapper) : ICreateProposalCase
{

    private readonly IProposalWriteOnlyRepository _proposalWriteOnlyRepository = proposalWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<BaseResponse<ResponseCreatedProposalDTO>> Execute(RequestProposalDTO request)
    {
        await Validate(request);

        var proposal = Proposal.Create(request.ProjectID, request.FreelancerId, request.ProposedValue, request.Message, request.Status);

        await _proposalWriteOnlyRepository.Add(proposal);
        await _unityOfWork.Commit();

        var proposalData = _mapper.Map<ResponseCreatedProposalDTO>(proposal);

        return new BaseResponse<ResponseCreatedProposalDTO>(proposalData);
    }  

    private static async Task Validate(RequestProposalDTO request)
    {
        var result = await new CreateProposalValidator().ValidateAsync(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
