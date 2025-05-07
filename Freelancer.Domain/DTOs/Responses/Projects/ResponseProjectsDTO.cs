namespace Freelancers.Domain.DTOs.Responses.Projects;

public class ResponseProjectsDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public DateTime DeadLine { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Bugdet { get; set; } = default!;
}
