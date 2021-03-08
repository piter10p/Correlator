using System;
using Microsoft.Extensions.DependencyInjection;

namespace Correlator.Core.Extensions.Microsoft.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCorrelationService(this IServiceCollection serviceCollection)
        {
            if (serviceCollection is null) throw new ArgumentNullException(nameof(serviceCollection));

            serviceCollection.AddScoped<ICorrelationService, CorrelationService>();

            return serviceCollection;
        }
    }
}