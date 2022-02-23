using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Logging.Elasticsearch
{
    public class ElasticsearchLoggerOptions
    {
        /// <summary>
        /// Es地址
        /// </summary>
        public List<string> ElasticsearchUrls { get; set; }
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
