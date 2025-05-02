using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Repositories.Projects;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Proposals;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.Entities;

namespace Freelancers.Application.UseCase.Auth.Proposals;

public class DeleteProposalUseCase(IProposalWriteOnlyRepository proposalWriteOnlyRepository, IUnityOfWork unityOfWork) : IDeleteProposalUseCase
{
    private readonly IProposalWriteOnlyRepository _proposaltWriteOnlyRepository = proposalWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;

    public async Task Execute(int proposalID)
    {
        var proposal = await _proposaltWriteOnlyRepository.Delete(proposalID);

        if (proposal == false)
            throw new NotFoundException("Proposata não encontrado");

        await _unityOfWork.Commit();
    }
}

