using ElasticSearch.Repository;
using ElasticSearch.Repository.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MicroHeart.Logging.Elasticsearch
{
    public static class ElasticsearchLoggerExtensions
    {
        public static IServiceCollection AddElasticsearchLogger(this IServiceCollection services)
        {
            services.AddElasticSearch();
            services.AddSingleton<ILoggerProvider, ElasticsearchLoggerProvider>();
            services.AddSingleton<IBaseRepository<LogEntity>, BaseRepository<LogEntity>>();
            services.AddScoped<EventIdProvider>();
            return services;
        }
    }
}
