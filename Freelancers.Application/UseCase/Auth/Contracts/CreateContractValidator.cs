using FluentValidation;
using Freelancers.Domain.DTOs.Requests.Contract;

namespace Freelancers.Application.UseCase.Auth.Contracts;

public class CreateContractValidator : AbstractValidator<RequestCreateContractDTO>
{
    public CreateContractValidator()
    {
        RuleFor(x => x.ProposalID)
            .NotEmpty()
            .WithMessage("A proposta deve existir");
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("A data inicial deve ser preenchido com uma data maior que a atual")
            .LessThan(x => x.EndDate)
            .WithMessage("Data menor que a data atual");
        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("A data final deve ser preenchido com uma data maior que a data inicial ")
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be greater than start date.");
    }

}
