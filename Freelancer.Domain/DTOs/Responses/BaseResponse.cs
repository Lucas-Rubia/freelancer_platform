namespace Freelancers.Domain.DTOs.Responses;

public class BaseResponse<TData>(TData? data, string? message = null)
{
    public TData? Data { get; set; } = data;
    public string? Message { get; set; } = message;
}
