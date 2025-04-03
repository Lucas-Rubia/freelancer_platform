using Freelancers.Application.UseCase.Auth.Contracts;
using Freelancers.Application.UseCase.Auth.Projects;
using Freelancers.Application.UseCase.Auth.Proposals;
using Freelancers.Application.UseCase.Auth.Reviwers;
using Freelancers.Application.UseCase.Auth.Users;
using Freelancers.Domain.Interfaces.Contract;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.Interfaces.Review;
using Freelancers.Domain.Interfaces.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Freelancers.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services) 
    {
        AddUseCases(services);
    } 

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        services.AddScoped<ICreateProjectCase, CreateProjectUseCase>();
        services.AddScoped<ICreateProposalCase, CreateProposalUseCase>();
        services.AddScoped<ICreateReviewCase, CreateReviewUseCase>();
        services.AddScoped<IGetAllProjectsUseCase, GetAllProjectsUseCase>();
        services.AddScoped<IGetAllProposalUseCase, GetAllProposalUseCase>();
        services.AddScoped<IGetAllUserUseCase, GetAllUserUseCase>();
        services.AddScoped<IGetAllReviewUseCase, GetAllReviewUseCase>();
        services.AddScoped<IGetAllContratcsUseCase, GetAllContractUseCase>();
    }

}
