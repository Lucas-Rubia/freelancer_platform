using Freelancers.Domain.DTOs.Requests.Project;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.Projects;

namespace Freelancers.Domain.Interfaces.Project;

public interface ICreateProjectCase
{
    Task<BaseResponse<ResponseCreateProjectDTO>> Execute(RequestProjectDTO request);
}
