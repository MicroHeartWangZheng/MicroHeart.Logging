using System;
using System.Collections.Generic;
using System.Text;

namespace MicroHeart.Logging.Elasticsearch
{
    internal class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();

        private NullScope()
        {
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}
