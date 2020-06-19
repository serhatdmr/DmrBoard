using DmrBoard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace DmrBoard.Domain.Utilities
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, IPagedResultRequest request)
        {
            query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);
            return query;
        }
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }
    }
}
