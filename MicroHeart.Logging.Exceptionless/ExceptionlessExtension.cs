using Exceptionless;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace MicroHeart.Logging.Exceptionless
{
    public static class ExceptionlessExtension
    {
        public static void UseExceptionlessLogging(this IApplicationBuilder app)
        {
            var provider = app.ApplicationServices;
            var configuration = provider.GetService<IConfiguration>();
            var loggerFactory = provider.GetService<ILoggerFactory>();

            app.UseExceptionless(configuration);

            var client = ExceptionlessClient.Default;
            client.Configuration.UseInMemoryStorage();

            loggerFactory.AddProvider(new ExlessLoggerProvider());
        }
    }
}
