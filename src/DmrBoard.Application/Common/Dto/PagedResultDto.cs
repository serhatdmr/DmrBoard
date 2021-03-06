﻿using DmrBoard.Core.Entities;
using System.Collections.Generic;

namespace DmrBoard.Application.Common.Dto
{
    public class PagedResultDto<T> : IPagedResult<T>
    {
        public IReadOnlyList<T> Items { get; set; }
        public int TotalCount { get; set; }

        private PagedResultDto()
        { }

        public PagedResultDto(IReadOnlyList<T> data, int totalCount)
        {
            Items = data;
            TotalCount = totalCount;
        }
    }
}
