using FluentValidation;
using Freelancers.Domain.DTOs.Requests.Proposal;

namespace Freelancers.Application.UseCase.Auth.Proposals;

internal class CreateProposalValidator : AbstractValidator<RequestProposalDTO>
{
    public CreateProposalValidator()
    {
        RuleFor(x => x.ProposedValue)
            .NotEmpty()
            .WithMessage("A proposta não pode ser vazia");

        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("O campo deve conter uma mensagem");

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("O stutus é invalido, é preciso escolher entre Accept, Pending ou Canceld");
    }
}
