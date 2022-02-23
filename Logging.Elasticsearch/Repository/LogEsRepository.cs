using ElasticSearch.Repository;
using Microsoft.Extensions.Options;
using Nest;

namespace Logging.Elasticsearch.Repository
{
    public class LogEsRepository : BaseRepository<LogEntity>, ILogEsRepository
    {

        public override string IndexName => nameof(LogEntity).ToLower();

        public override int NumberOfReplicas => 1;

        public override int NumberOfShards => 1;

        public LogEsRepository(IElasticClient client, IOptions<ElasticSearchOptions> options) : base(client, options)
        {
        }
    }
}
