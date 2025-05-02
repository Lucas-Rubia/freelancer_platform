using System.Data;
using FluentValidation;
using Freelancers.Domain.DTOs.Requests.Review;

namespace Freelancers.Application.UseCase.Auth.Reviwers;

public class CreateReviewValidator : AbstractValidator<RequestReviewDTO>
{
    public CreateReviewValidator()
    {
        RuleFor(x => x.Rating)
            .NotEmpty()
            .WithMessage("Avaliação não pode ser vazio");

        RuleFor(x => x.Comment)
            .NotEmpty()
            .WithMessage("É preciso ter um comentario");
    }
}
