using Freelancers.Domain.Repositories;
using Freelancers.Domain.Security.Cryptography;
using Freelancers.Infrastructure.DataAccess;
using Freelancers.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Freelancers.Infrastructure;

public static class DependecyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDBContext(services, configuration);
        AddRepositories(services);

        services.AddScoped<IPasswordEncryption, Security.Cryptography.BCrypt>();
    }

    private static void AddDBContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FreelancersDbContext>(
            x => x.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IProjectReadOnlyRepository, ProjectRepository>();
        services.AddScoped<IProjectWriteOnlyRepository, ProjectRepository>();
        services.AddScoped<IProposalReadOnlyRepository, ProposalRepository>();
        services.AddScoped<IProposalWriteOnlyRepository, ProposalRepository>();
    }
}
