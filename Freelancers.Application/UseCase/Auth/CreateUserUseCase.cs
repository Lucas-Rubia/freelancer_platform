using Freelancers.Domain.DTOs.Requests;
using Freelancers.Domain.DTOs.Responses;
using Freelancers.Domain.Entities;
using Freelancers.Domain.Exceptions;
using Freelancers.Domain.Interfaces.Users;
using Freelancers.Domain.Repositories;
using Freelancers.Domain.Security.Cryptography;

namespace Freelancers.Application.UseCase.Auth;

public class CreateUserUseCase(
    IUserWriteOnlyRepository userWriteOnlyRepository,
    IUnityOfWork unityOfWork, 
    IPasswordEncryption passwordEncryption) : ICreateUserUseCase
{
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository = userWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IPasswordEncryption _passwordEncryption = passwordEncryption;

    public async Task<ResponseCreatedUserDTO> Execute(RequestUserDTO request)
    {
        await Validate(request);

        request.Password = _passwordEncryption.Encrypt(request.Password);

        var user = User.Create(request.Name, request.Email, request.Password, request.UserType);

        await _userWriteOnlyRepository.Add(user);
        await _unityOfWork.Commit();

        return new ResponseCreatedUserDTO
        {
            Name = user.Name,
            UserType = user.UserType
        };
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
