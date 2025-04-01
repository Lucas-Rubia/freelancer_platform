using FluentValidation;
using Freelancers.Domain.DTOs.Requests;

namespace Freelancers.Application.UseCase.Auth;

public class CreateUserValidator : AbstractValidator<RequestUserDTO>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nome não pode ser vazio");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email inválido");

        RuleFor(x => x.Password)
            .Length(6, 20)
            .WithMessage("A senha deve ter entre 6 e 20 caracteres.");


        RuleFor(x => x.UserType)
            .IsInEnum()
            .WithMessage("Tipo de usuário não é válido!");
    }
}
