﻿using Freelancers.Application.AutoMapper;
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
        AddAutoMapper(services);
    } 

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
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
        services.AddScoped<IProcessProposalStatusUseCase, ProcessProposalStatusUseCase>();
        services.AddScoped<IProcessProposalInformationUseCase, ProcessProposalInformationUseCase>();
        services.AddScoped<IProcessProjectInformationUseCase, ProcessProjectInformationUseCase>();
        services.AddScoped<ICreateContractUseCase, CreateContractUseCase>();
        services.AddScoped<IAcceptTermsOfContractUseCase, AcceptTermsOfContractUseCase>();
        services.AddScoped<IDeleteProjectUseCase, DeleteProjectUseCase>();
        services.AddScoped<IDeleteProposalUseCase, DeleteProposalUseCase>();
    }

}
