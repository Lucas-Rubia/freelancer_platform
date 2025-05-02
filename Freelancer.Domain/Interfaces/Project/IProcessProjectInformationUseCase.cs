using Freelancers.Domain.DTOs.Responses.Projects;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Requests.Project;

namespace Freelancers.Domain.Interfaces.Project;

public interface IProcessProjectInformationUseCase
{
    Task<BaseResponse<ResponseProjectInformationDTO>> Execute(RequestProjectInformationDTO request);
}
