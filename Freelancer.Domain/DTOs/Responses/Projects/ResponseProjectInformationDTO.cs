namespace Freelancers.Domain.DTOs.Responses.Projects;

public class ResponseProjectInformationDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime DeadLine { get; set; } = default!;
    public decimal Bugdet { get; set; } = default!;
}
