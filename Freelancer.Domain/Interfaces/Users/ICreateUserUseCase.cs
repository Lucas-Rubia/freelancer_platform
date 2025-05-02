using Freelancers.Domain.DTOs.Requests.User;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.User;

namespace Freelancers.Domain.Interfaces.Users;

public interface ICreateUserUseCase
{
    Task<BaseResponse<ResponseCreatedUserDTO>> Execute(RequestUserDTO request);
}
