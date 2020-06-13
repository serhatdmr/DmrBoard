using System.Collections.Generic;

namespace DmrBoard.Core.Entities
{
    public interface IPagedResult<T>
    {
        public IReadOnlyList<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
