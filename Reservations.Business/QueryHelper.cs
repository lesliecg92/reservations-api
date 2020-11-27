using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reservations.Business
{
    public static class QueryHelper<T> where T : class
    {
        public static async Task<(IEnumerable<T>, int)> ApplyPagination(IQueryable<T> query, int pageSize, int page)
        {
            var total = query.Count();

            query = query.Skip(pageSize * (page - 1)).Take(pageSize);

            return await query.ToListAsync().ContinueWith(c => (c.Result, total));
        }

        public static IQueryable<TEntity> ApplyOrder<TEntity>(IQueryable<TEntity> query, string orderBy,
            string sortOrder)
            where TEntity : class
        {
            var exp = BuildExpression<TEntity>(orderBy);

            query = sortOrder == "asc" ? query.OrderBy(exp) : query.OrderByDescending(exp);

            return query;
        }

        private static Expression<Func<TEntity, object>> BuildExpression<TEntity>(string propName) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var propertyOrField = propName.Split(".").Aggregate((Expression)parameter, Expression.PropertyOrField);
            var unaryExpression = Expression.MakeUnary(ExpressionType.Convert, propertyOrField, typeof(object));

            return Expression.Lambda<Func<TEntity, object>>(unaryExpression, parameter);
        }

    }
}
