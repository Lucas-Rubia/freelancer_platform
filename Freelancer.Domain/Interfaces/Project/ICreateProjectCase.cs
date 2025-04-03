using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses.Projects;

namespace Freelancers.Domain.Interfaces.Project;

public interface ICreateProjectCase
{
    Task<ResponseCreateProjectDTO> Execute(RequestProjectDTO request);
}
