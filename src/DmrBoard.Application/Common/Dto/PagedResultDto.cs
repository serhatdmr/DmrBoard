using DmrBoard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Application.Common.Dto
{
    public class PagedResultDto<T> : IPagedResult<T>
    {
        public IReadOnlyList<T> Data { get; set; }
        public int TotalCount { get; set; }

        public PagedResultDto()
        { }

        public PagedResultDto(IReadOnlyList<T> data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }
    }
}
