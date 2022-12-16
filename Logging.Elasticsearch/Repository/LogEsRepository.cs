using ElasticSearch.Repository;
using Microsoft.Extensions.Options;
using Nest;

namespace Logging.Elasticsearch.Repository
{
    public class LogEsRepository : BaseRepository<LogEntity>, ILogEsRepository
    {
        public LogEsRepository(IElasticClient client, IOptions<ElasticSearchOptions> options) : base(client, options)
        {
        }
    }
}
