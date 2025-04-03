using FluentValidation;
using Freelancers.Domain.DTOs.Requests;

namespace Freelancers.Application.UseCase.Auth.Projects;

internal class CreateProjectValidator : AbstractValidator<RequestProjectDTO>
{
    public CreateProjectValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("itulo não pode ser vazio");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Descrição não pode ser vazia");

        RuleFor(x => x.DeadLine)
            .NotEmpty()
            .WithMessage("A DeadLine não pode ser vazia");

        RuleFor(x => x.Bugdet)
            .NotEmpty()
            .WithMessage("O Bugdet deve não pode ser vazio e deve conter um valor acima de 0");
    }
}
