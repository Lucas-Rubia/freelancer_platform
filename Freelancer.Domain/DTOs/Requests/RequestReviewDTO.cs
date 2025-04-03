namespace Freelancers.Domain.DTOs.Requests;

public class RequestReviewDTO
{
    public int ContractID { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}
