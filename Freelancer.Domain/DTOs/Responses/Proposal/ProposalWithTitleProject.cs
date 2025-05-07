using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Responses.Proposal;

public class ProposalWithTitleProject
{
    public int Id { get; set; }
    public decimal ProposedValue { get; set; }
    public string Message { get; set; } = default!;
    public string TitleProject { get; set; } = default!;
    public EBaseStatus Status { get; set; }
}
