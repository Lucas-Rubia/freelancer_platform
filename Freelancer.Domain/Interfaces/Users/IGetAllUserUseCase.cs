using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.User;

namespace Freelancers.Domain.Interfaces.Users;

public interface IGetAllUserUseCase
{
    Task <BasePagedResponse<List<ResponseUserDTO>?>> Execute(int pageSize, int pageNumber);
}
