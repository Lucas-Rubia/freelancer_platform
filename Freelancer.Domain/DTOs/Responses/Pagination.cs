namespace Freelancers.Domain.DTOs.Responses;

public class Pagination
{
    public int CurrentPage { get; set; } = APIConfiguration.DefaultCurrentPage;
    public int PageSize { get; set; } = APIConfiguration.DefaultPageSize;
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public int TotalCount { get; set; }
}
