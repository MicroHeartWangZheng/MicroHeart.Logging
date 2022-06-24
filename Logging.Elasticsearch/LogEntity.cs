using Nest;
using System;

namespace Logging.Elasticsearch
{
    public class LogEntity
    {
        [Keyword]
        public long Id { get; set; } = DateTime.Now.Ticks;

        [Keyword]
        public string ProjectName { get; set; }

        [Keyword]
        public string Level { get; set; }

        [Text]
        public string Message { get; set; }

        [Keyword]
        public string EventId { get; set; }

        [Keyword]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
