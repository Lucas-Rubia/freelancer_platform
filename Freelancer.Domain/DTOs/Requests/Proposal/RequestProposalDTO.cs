using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Requests.Proposal;

public class RequestProposalDTO
{
    public int ProjectID { get; set; }
    public int FreelancerId { get; set; }
    public decimal ProposedValue { get; set; }
    public string Message { get; set; } = default!;
    public EBaseStatus Status { get; set; } = EBaseStatus.Pending;
}
