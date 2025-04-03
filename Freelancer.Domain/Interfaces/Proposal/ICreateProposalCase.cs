using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses.Proposal;

namespace Freelancers.Domain.Interfaces.Proposal;

public interface ICreateProposalCase
{
    Task<ResponseCreatedProposalDTO> Execute(RequestProposalDTO request);
}
