using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses.User;

namespace Freelancers.Domain.Interfaces.Users;

public interface ICreateUserUseCase
{
    Task<ResponseCreatedUserDTO> Execute(RequestUserDTO request);
}
