using Exceptionless;
using Microsoft.Extensions.Logging;
using System;

namespace MicroHeart.Logging.Exceptionless
{
    public class ExceptionlessLogger : ILogger
    {
        private readonly string _categoryName;
        public ExceptionlessLogger(string categoryName)
        {
            _categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NoopDisposable.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            var source = $"{_categoryName}{eventId}";
            ExceptionlessClient.Default
                .CreateLog(source, message, logLevel.ToString())
                .Submit();
        }

        private class NoopDisposable : IDisposable
        {
            public static NoopDisposable Instance = new NoopDisposable();

            public void Dispose()
            {
            }
        }
    }
}
