using ChallengeRandomUserGeneratorAPI.Application.Interfaces;
using ChallengeRandomUserGeneratorAPI.Infrastructure.ExternalServices;

namespace ChallengeRandomUserGeneratorAPI.Infrastructure.Dependency
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient<IRandomUserGeneratorService, RUGService>();

            return services;
        }

    }
}
