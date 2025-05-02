using AutoMapper;
using Freelancers.Domain.DTOs.Requests.User;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.DTOs.Responses.User;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Interfaces.Users;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Repositories.Users;
using Freelancers.Domain.Security.Cryptography;

namespace Freelancers.Application.UseCase.Auth.Users;

public class CreateUserUseCase(
    IUserWriteOnlyRepository userWriteOnlyRepository,
    IUnityOfWork unityOfWork, 
    IPasswordEncryption passwordEncryption,
    IMapper mapper) : ICreateUserUseCase
{
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository = userWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IPasswordEncryption _passwordEncryption = passwordEncryption;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<ResponseCreatedUserDTO>> Execute(RequestUserDTO request)
    {
        await Validate(request);

        request.Password = _passwordEncryption.Encrypt(request.Password);

        var user = User.Create(request.Name, request.Email, request.Password, request.UserType);

        await _userWriteOnlyRepository.Add(user);
        await _unityOfWork.Commit();

        var userData = _mapper.Map<ResponseCreatedUserDTO>(user);

        return new BaseResponse<ResponseCreatedUserDTO>(userData);

    }

    private static async Task Validate(RequestUserDTO request)
    {
        var result = await new CreateUserValidator().ValidateAsync(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
