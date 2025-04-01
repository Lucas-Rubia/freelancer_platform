namespace Freelancers.Domain.DTOs.Responses
{
    public class ResponseCreateProjectDTO
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime DeadLine { get; set; } = default!;
        public decimal Bugdet { get; set; }
    }
}
