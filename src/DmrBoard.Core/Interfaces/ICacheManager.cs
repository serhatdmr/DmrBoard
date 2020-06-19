using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Core.Interfaces
{
    public interface ICacheManager : IMemoryCache
    {
        /// <summary>
        /// Clears all entries
        /// </summary>
        void ClearAll();
    }
}
