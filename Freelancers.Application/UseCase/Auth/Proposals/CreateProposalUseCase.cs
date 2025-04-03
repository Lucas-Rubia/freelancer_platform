using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses.Proposal;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Proposals;

namespace Freelancers.Application.UseCase.Auth.Proposals;

public class CreateProposalUseCase(IProposalWriteOnlyRepository proposalWriteOnlyRepository, IUnityOfWork unityOfWork) : ICreateProposalCase
{

    private readonly IProposalWriteOnlyRepository _proposalWriteOnlyRepository = proposalWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    public async Task<ResponseCreatedProposalDTO> Execute(RequestProposalDTO request)
    {
        await Validate(request);

        var proposal = Proposal.Create(request.ProjectID, request.FreelancerId, request.ProposedValue, request.Message, request.Status);

        await _proposalWriteOnlyRepository.Add(proposal);
        await _unityOfWork.Commit();

        return new ResponseCreatedProposalDTO
        {
            ProposedValue = request.ProposedValue,
            Message = request.Message,
            Status = request.Status
        };
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
