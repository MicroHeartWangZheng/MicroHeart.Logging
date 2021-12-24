using Microsoft.Extensions.Logging;
using System;

namespace MicroHeart.Logging.Elasticsearch
{
    public class EventIdProvider
    {
        public EventId EventId { get; }

        public EventIdProvider()
        {
            var name = $"{DateTime.Now.ToString("yyyyMMddHHmmssfffff")}";
            EventId = new EventId(0, name);
        }
    }
}
