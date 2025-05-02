namespace Freelancers.Domain.DTOs.Requests.Project;

public class RequestProjectInformationDTO
{
    public int ProjectID { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime DeadLine { get; set; } = default!;
    public decimal Bugdet { get; set; } = default!;

}
