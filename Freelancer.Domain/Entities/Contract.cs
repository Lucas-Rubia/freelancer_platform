using Freelancers.Domain.Enums;
using Freelancers.Domain.Models;

namespace Freelancers.Domain.Entities;

public class Contract : BaseModel
{
    public int Id { get; set; }
    public int ProposalID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public EBaseStatus Status { get; set; } = EBaseStatus.Pending;

    public Proposal Proposal { get; set; } = default!;
    public Review Review { get; set; } = default!;

}
