using ElasticSearch.Repository;
using Logging.Elasticsearch.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Logging.Elasticsearch
{
    public class ElasticsearchLoggerProvider : ILoggerProvider
    {
        private readonly ILogEsRepository logEsRepository;

        private ElasticsearchLoggerOptions options;

        public ElasticsearchLoggerProvider(ILogEsRepository logEsRepository,
            IOptions<ElasticsearchLoggerOptions> options)
        {
            this.logEsRepository = logEsRepository;
            this.options = options.Value;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ElasticsearchLogger(logEsRepository, options);
        }

        public void Dispose()
        {

        }
    }
}
