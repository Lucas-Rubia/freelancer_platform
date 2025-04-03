namespace Freelancers.Domain.DTOs.Responses.Review;

public class ResponseCreateReviewDTO
{
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}
