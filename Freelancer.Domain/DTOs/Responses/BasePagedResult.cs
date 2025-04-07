namespace Freelancers.Domain.DTOs.Responses;

public class BasePagedResult<TData>(TData data, int totalCount)
{
    public TData Data { get; set; } = data;
    public int TotalCount { get; set; } = totalCount;
}
