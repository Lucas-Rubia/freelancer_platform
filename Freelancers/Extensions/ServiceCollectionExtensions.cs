using Freelancers.Application;
using Freelancers.Filters;
using Freelancers.Infrastructure;

namespace Freelancers.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
        services.AddInfrastructure(configuration);
        services.AddApplication();
        
        return services;
    }

    public static IServiceCollection AddSwaggerDocumantation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddUseCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        return services;
    }
}
