using MicroHeart.Logging.Elasticsearch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroHeart.Logging.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly EventIdProvider _eventIdProvider;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, EventIdProvider eventIdProvider)
        {
            _logger = logger;
            _eventIdProvider = eventIdProvider;

        }

        [HttpGet]
        public void Get()
        {
            _logger.LogDebug(_eventIdProvider.EventId, "测试Debug");
            _logger.LogInformation(_eventIdProvider.EventId, "测试哈哈哈哈");
            LogA();
            LogB();
        }


        public void LogA()
        {
            _logger.LogInformation(_eventIdProvider.EventId, "LogA");
        }


        public void LogB()
        {
            _logger.LogInformation(_eventIdProvider.EventId, "LogB");
        }


    }
}
