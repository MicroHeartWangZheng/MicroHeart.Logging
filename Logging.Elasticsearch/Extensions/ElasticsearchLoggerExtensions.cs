using ElasticSearch.Repository.Extensions;
using Logging.Elasticsearch.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace Logging.Elasticsearch
{
    public static class ElasticsearchLoggerExtensions
    {
        public static IServiceCollection AddElasticsearchLogger(this IServiceCollection services, Action<ElasticsearchLoggerOptions> configAction)
            => AddElasticsearchLogger(services, (serviceProvider, options) => configAction.Invoke(options));


        public static IServiceCollection AddElasticsearchLogger(this IServiceCollection services, Action<IServiceProvider, ElasticsearchLoggerOptions> configAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (configAction == null)
                throw new ArgumentNullException(nameof(configAction));

            services.AddOptions<ElasticsearchLoggerOptions>()
                    .Configure<IServiceProvider>((options, sp) => configAction(sp, options));

            services.AddSingleton<ILoggerProvider, ElasticsearchLoggerProvider>();
            services.AddSingleton<ILogEsRepository, LogEsRepository>();
            services.AddScoped<EventIdProvider>();

            services.AddElasticSearch((serviceProvider, options) =>
            {
                var logOptions = serviceProvider.GetService<IOptions<ElasticsearchLoggerOptions>>().Value;
                options.IndexPrefix = string.Empty;
                options.DisableDirectStreaming = false;
                options.ConnectionStrings = logOptions.ElasticsearchUrls;
            });
            return services;
        }
    }
}
