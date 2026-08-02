using AI.PM.Domain.Interfaces;
using AI.PM.Infrastructure.AI;
using AI.PM.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AI.PM.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<OpenAISettings>(
            configuration.GetSection(OpenAISettings.SectionName));

        services.AddScoped<IAIClient, OpenAIChatClient>();

        return services;
    }
}