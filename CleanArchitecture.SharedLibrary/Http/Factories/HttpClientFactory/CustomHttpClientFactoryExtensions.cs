using System;
using System.Collections.Generic;
using System.Text;
using Prism.Ioc;

namespace CleanArchitecture.SharedLibrary.Http.Factories.HttpClientFactory
{
    public static class CustomHttpClientFactoryExtensions
    {

        public static IContainerRegistry RegisterCustomHttpClientFactory(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICustomHttpClientFactory, CustomHttpClientFactory>();
            return containerRegistry;
        }
    }
}
