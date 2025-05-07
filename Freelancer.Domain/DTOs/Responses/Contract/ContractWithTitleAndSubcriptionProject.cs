using Freelancers.Domain.Enums;

namespace Freelancers.Domain.DTOs.Responses.Contract;

public class ContractWithTitleAndSubcriptionProject
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string TitleProject { get; set; } = default!;
    public string SubcriptionProject { get; set; } = default!;
    public EBaseStatus Status { get; set; }
}
