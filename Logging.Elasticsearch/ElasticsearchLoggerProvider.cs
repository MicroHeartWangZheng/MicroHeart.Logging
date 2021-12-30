using ElasticSearch.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Logging.Elasticsearch
{
    public class ElasticsearchLoggerProvider : ILoggerProvider
    {
        private readonly IBaseRepository<LogEntity> logRepository;

        private ElasticsearchLoggerOptions options;

        public ElasticsearchLoggerProvider(IBaseRepository<LogEntity> logRepository,
            IOptions<ElasticsearchLoggerOptions> options)
        {
            this.logRepository = logRepository;
            this.options = options.Value;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ElasticsearchLogger(logRepository, options);
        }

        public void Dispose()
        {

        }
    }
}
