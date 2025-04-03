using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.Interfaces.Users;
using Freelancers.Domain.Repositories.Users;

namespace Freelancers.Application.UseCase.Auth.Users;

public class GetAllUserUseCase(IUserReadOnlyRepository userReadOnlyRepository) : IGetAllUserUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository = userReadOnlyRepository;

    public async Task<BaseResponse<List<ResponseUserDTO>?>> Execute()
    {
        var users = await _userReadOnlyRepository.GetAllAsync();

        if (users is null)
            return new BaseResponse<List<ResponseUserDTO>?>([], "Usuario não encontrado ou não cadastrado");

        var userData = users?.Select(x => new ResponseUserDTO { 
            Id = x.Id,
            Name = x.Name,
            UserType = x.UserType
        }).ToList();

        var usersDTO = new BaseResponse<List<ResponseUserDTO>?>(userData, "Usuario(s) encontrado(s) com sucesso");

        return usersDTO;
    }
}
