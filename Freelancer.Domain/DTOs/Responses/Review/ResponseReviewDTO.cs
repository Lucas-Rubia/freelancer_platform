namespace Freelancers.Domain.DTOs.Responses.Review;

public class ResponseReviewDTO
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;

}
