using AI.PM.Domain.Interfaces;
using AI.PM.Infrastructure.AI;
using Microsoft.Extensions.DependencyInjection;

namespace AI.PM.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient<IAIClient, OpenAIChatClient>();

        return services;
    }
}
