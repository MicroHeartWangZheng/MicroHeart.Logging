using Microsoft.Extensions.Logging;
using System;

namespace MicroHeart.Logging.Elasticsearch
{
    public class EventIdProvider
    {
        public EventId EventId { get; }

        public EventIdProvider()
        {
            var id = (int)(DateTime.Now.Ticks % int.MaxValue);
            var name = $"{DateTime.Now.ToString("yyyyMMddHHmmssfffff")}";
            EventId = new EventId(id, name);
        }
    }
}
