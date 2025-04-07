using AutoMapper;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.Interfaces.Users;
using Freelancers.Domain.Repositories.Users;

namespace Freelancers.Application.UseCase.Auth.Users;

public class GetAllUserUseCase(IUserReadOnlyRepository userReadOnlyRepository, IMapper mapper) : IGetAllUserUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository = userReadOnlyRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<BasePagedResponse<List<ResponseUserDTO>?>> Execute(int pageSize, int pageNumber)
    {
        var users = await _userReadOnlyRepository.GetAllAsync(pageSize, pageNumber);

        if (users is null)
            return new BasePagedResponse<List<ResponseUserDTO>?>([], "Usuario não encontrado ou não cadastrado");

        var userData = _mapper.Map<List<ResponseUserDTO>>(users.Data);

        var usersDTO = new BasePagedResponse<List<ResponseUserDTO>?>(
            userData,
            users!.TotalCount,
            pageSize,
            pageNumber);

        return usersDTO;
    }
}
