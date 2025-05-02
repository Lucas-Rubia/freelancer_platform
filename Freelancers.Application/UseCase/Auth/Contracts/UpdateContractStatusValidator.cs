using FluentValidation;
using Freelancers.Domain.DTOs.Requests.Contract;

namespace Freelancers.Application.UseCase.Auth.Contracts;

public class UpdateContractStatusValidator : AbstractValidator<RequestContractStatusDTO>
{
    public UpdateContractStatusValidator()
    {
        RuleFor(x => x.ContractID)
            .NotEmpty()
            .WithMessage("O ID do contrato não pode ser vazio");
        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("O status deve ser um valor válido");
    }

}
