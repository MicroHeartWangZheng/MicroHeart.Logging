using Microsoft.Extensions.Logging;

namespace MicroHeart.Logging.Exceptionless
{
    public class ExlessLoggerProvider : ILoggerProvider
    {
        
        public ILogger CreateLogger(string categoryName)
        {
            return new ExceptionlessLogger(categoryName);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
        }
    }
}
