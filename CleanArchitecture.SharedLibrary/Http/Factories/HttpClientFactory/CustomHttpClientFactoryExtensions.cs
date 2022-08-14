using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.SharedLibrary.Http.Factories.HttpClientFactory
{
    public static class CustomHttpClientFactoryExtensions
    {

        public static IServiceCollection RegisterCustomHttpClientFactory(this IServiceCollection services)
        {
            services.AddSingleton<ICustomHttpClientFactory, CustomHttpClientFactory>();
            return services;
        }
    }
}
