using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses;

namespace Freelancers.Domain.Interfaces.Users;

public interface ICreateUserUseCase
{
    Task<ResponseCreatedUserDTO> Execute(RequestUserDTO request);
}
