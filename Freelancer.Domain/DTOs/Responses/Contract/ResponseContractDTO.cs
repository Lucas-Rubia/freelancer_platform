using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Responses.Contract;

public class ResponseContractDTO
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public EBaseStatus Status { get; set; } = EBaseStatus.Pending;
}
