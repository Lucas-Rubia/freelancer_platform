using System.Text.Json.Serialization;

namespace Freelancers.Domain.DTOs.Responses;

public class BasePagedResponse<TData> : BaseResponse<TData>
{

    public Pagination Pagination { get; set; }

    [JsonConstructor]
    public BasePagedResponse(
        TData? data, 
        int totalCount,
        int currentPage = APIConfiguration.DefaultCurrentPage, 
        int pageSize = APIConfiguration.DefaultPageSize) : base(data)
    {
        Data = data;
        Pagination = new Pagination
        {
            TotalCount = totalCount,
            CurrentPage = currentPage,
            PageSize = pageSize,
        };
    }

    public BasePagedResponse(TData? data, string? message = null) : base(data, message) 
    { 
    }


}
