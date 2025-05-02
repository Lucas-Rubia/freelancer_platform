namespace Freelancers.Domain.DTOs.Requests.Contract;

public class RequestCreateContractDTO
{
    public int ProposalID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
