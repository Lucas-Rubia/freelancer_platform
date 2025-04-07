using System.Text.Json.Serialization;

namespace Freelancers.Domain.DTOs.Responses;

public class BasePagedResponse<TData> : BaseResponse<TData>
{
    public int CurrentPage { get; set; } = APIConfiguration.DefaultCurrentPage;
    public int PageSize { get; set; } = APIConfiguration.DefaultPageSize;
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public int TotalCount { get; set; }

    [JsonConstructor]
    public BasePagedResponse(
        TData? data, 
        int totalCount,
        int currentPage = APIConfiguration.DefaultCurrentPage, 
        int pageSize = APIConfiguration.DefaultPageSize) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public BasePagedResponse(TData? data, string? message = null) : base(data, message) 
    { 
    }


}
