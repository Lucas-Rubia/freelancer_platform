namespace Freelancers.Domain.DTOs.Requests.Project;

public class RequestProjectDTO
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime DeadLine { get; set; } = default!;
    public decimal Bugdet { get; set; }
    public int UserId { get; set; }

}
