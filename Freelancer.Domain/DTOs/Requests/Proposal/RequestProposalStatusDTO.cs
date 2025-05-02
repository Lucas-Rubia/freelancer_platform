using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Requests.Proposal;

public class RequestProposalStatusDTO
{
    public int ProposalID { get; set; }
    public EBaseStatus Status { get; set; }
}
