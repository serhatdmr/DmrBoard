using DmrBoard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Application.Dto
{
    public class PagedResultDto<T> : IPagedResult<T>
    {
        public IReadOnlyList<T> Items { get; private set; }
        public int TotalCount { get; private set; }

        private PagedResultDto()
        {

        }
        public PagedResultDto(IReadOnlyList<T> data, int totalCount)
        {
            Items = data;
            TotalCount = totalCount;
        }
    }
}
