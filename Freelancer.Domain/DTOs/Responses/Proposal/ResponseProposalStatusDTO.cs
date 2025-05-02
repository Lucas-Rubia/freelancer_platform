using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Responses.Proposal;

public class ResponseProposalStatusDTO
{
    public int Id { get; set; }
    public EBaseStatus Status { get; set; }
}
