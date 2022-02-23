using Microsoft.Extensions.Logging;
using System;

namespace Logging.Elasticsearch
{
    public class EventIdProvider
    {
        public EventId EventId { get; set; }

        public EventIdProvider()
        {
            var name = $"{DateTime.Now.ToString("yyyyMMddHHmmssfffff")}";
            EventId = new EventId(0, name);
        }
    }
}
