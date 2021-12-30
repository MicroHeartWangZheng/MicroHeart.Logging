using ElasticSearch.Repository;
using Microsoft.Extensions.Logging;
using System;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace MicroHeart.Logging.Elasticsearch
{
    public class ElasticsearchLogger : ILogger
    {
        private readonly IBaseRepository<LogEntity> logRepository;
        private ElasticsearchLoggerOptions options;
        public ElasticsearchLogger(IBaseRepository<LogEntity> logRepository, ElasticsearchLoggerOptions options)
        {
            this.logRepository = logRepository;
            this.options = options;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NullScope.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= options.Level ? true : false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;
            string message = string.Empty;
            if (formatter != null)
                message = formatter(state, exception);
            else if (state != null)
                message += state;

            if (exception != null)
            {
                string exceptionDelimiter = string.IsNullOrEmpty(message) ? string.Empty : " ";
                message += exceptionDelimiter + exception;
            }

            if (string.IsNullOrEmpty(message))
                return;

            logRepository.Insert(new LogEntity()
            {
                EventId = eventId.Name,
                Level = logLevel.ToString(),
                Message = message,
                ProjectName = options.ProjectName
            });
        }
    }
}
