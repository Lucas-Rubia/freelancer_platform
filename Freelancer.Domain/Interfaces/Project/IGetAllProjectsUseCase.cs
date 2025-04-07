using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Projects;

namespace Freelancers.Domain.Interfaces.Project;

public interface IGetAllProjectsUseCase
{
    Task<BasePagedResponse<List<ResponseProjectsDTO>?>> Execute(int pageSize, int pageNumber);
}
