using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Responses.Proposal;

public class ResponseCreatedProposalDTO
{
    public decimal ProposedValue { get; set; }
    public string Message { get; set; } = default!;
    public EBaseStatus Status { get; set; } = EBaseStatus.Pending;
}
