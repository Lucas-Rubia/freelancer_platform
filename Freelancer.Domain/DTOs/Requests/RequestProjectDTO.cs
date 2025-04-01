namespace Freelancers.Domain.DTOs.Requests;

public class RequestProjectDTO
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime DeadLine { get; set; } = default!;
    public decimal Bugdet { get; set; }
    public int UserId { get; set; }

}
