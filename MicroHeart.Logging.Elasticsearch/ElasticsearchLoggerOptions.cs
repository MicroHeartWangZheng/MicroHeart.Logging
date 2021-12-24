using Microsoft.Extensions.Logging;

namespace MicroHeart.Logging.Elasticsearch
{
    public class ElasticsearchLoggerOptions
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 记录等级
        /// </summary>
        public LogLevel Level { get; set; }
    }
}
