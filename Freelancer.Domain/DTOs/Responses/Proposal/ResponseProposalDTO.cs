namespace Freelancers.Domain.DTOs.Responses.Proposal;

public class ResponseProposalDTO
{
    public int Id { get; set; }
    public decimal ProposedValue { get; set; }
    public string Message { get; set; } = default!;
}
