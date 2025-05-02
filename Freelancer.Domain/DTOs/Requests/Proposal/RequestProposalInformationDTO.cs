namespace Freelancers.Domain.DTOs.Requests.Proposal;

public class RequestProposalInformationDTO
{
    public int ProposalID { get; set; }
    public decimal ProposedValue { get; set; }
    public string Message { get; set; } = default!;
}
