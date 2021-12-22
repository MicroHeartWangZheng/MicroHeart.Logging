using Microsoft.Extensions.Logging;
using Nest;
using System;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace MicroHeart.Logging.Elasticsearch
{
    public class LogEntity
    {
        [Keyword]
        public LogLevel Level { get; set; }

        [Keyword]
        public string Message { get; set; }

        [Object]
        public EventId EventId { get; set; }

        [Keyword]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
