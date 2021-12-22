using ElasticSearch.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace MicroHeart.Logging.Elasticsearch
{
    public class ElasticsearchLoggerProvider : ILoggerProvider
    {
        private readonly IBaseRepository<LogEntity> logRepository;

        public ElasticsearchLoggerProvider(IBaseRepository<LogEntity> logRepository)
        {
            this.logRepository = logRepository;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ElasticsearchLogger(logRepository);
        }

        public void Dispose()
        {

        }
    }
}
