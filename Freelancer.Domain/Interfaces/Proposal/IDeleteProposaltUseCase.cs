namespace Freelancers.Domain.Interfaces.Proposal;

public interface IDeleteProposalUseCase
{
    Task Execute(int proposalId);
}
