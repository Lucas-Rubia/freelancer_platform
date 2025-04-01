using Freelancers.Application.UseCase.Auth;
using Freelancers.Domain.Interfaces.Project;
using Freelancers.Domain.Interfaces.Proposal;
using Freelancers.Domain.Interfaces.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Freelancers.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services) 
    {
        AddUseCases(services);
        AddProjectCases(services);
        AddProposalCases(services);
    } 

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
    }

    private static void AddProjectCases(IServiceCollection services)
    {
        services.AddScoped<ICreateProjectCase, CreateProjectUseCase>();
    }
    private static void AddProposalCases(IServiceCollection services)
    {
        services.AddScoped<ICreateProposalCase, CreateProposalUseCase>();
    }
}
