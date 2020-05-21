using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Core.Service
{
    public abstract class DomainServiceBase<T> 
    {
        public readonly ILogger _logger;

        public DomainServiceBase(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
