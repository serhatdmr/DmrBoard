using System.Collections.Generic;

namespace DmrBoard.Core.Entities
{
    public interface IPagedResult<T>
    {
        public IReadOnlyList<T> Items { get;  }
        public int TotalCount { get; }
    }
}
