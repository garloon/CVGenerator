using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    public static class ModelExtensions
    {
        public static IQueryable<TEntity> AddTakeCount<TEntity, TKey, TContext>(this IExtendedBaseFilterModel<TEntity, TKey, TContext> model, IQueryable<TEntity> query)
            where TEntity : IEntityBase<TKey>, new()
            where TContext : DbContext
        {
            if (model.TakeCount != int.MaxValue)
            {
                query = query.Take(model.TakeCount);
            }

            return query;
        }

        public static IQueryable<TEntity> AddSkipCount<TEntity, TKey, TContext>(this IExtendedBaseFilterModel<TEntity, TKey, TContext> model, IQueryable<TEntity> query)
            where TContext : DbContext
            where TEntity : IEntityBase<TKey>, new()
        {
            if (model.SkipCount != 0)
            {
                query = query.Skip(model.SkipCount);
            }

            return query;
        }

        public static IQueryable<TEntity> AddOrder<TEntity, TKey, TContext>(this IExtendedBaseFilterModel<TEntity, TKey, TContext> model, IQueryable<TEntity> query)
            where TEntity : IEntityBase<TKey>, new()
            where TContext : DbContext
        {
            if (model.TakeCount > 1)
            {
                query = !string.IsNullOrEmpty(model.Ordering) ? query.OrderBy(model.Ordering, model.Ascending) : query.OrderBy(e => e.Id);
            }

            return query;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, bool ascending = true)
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type, "p");

            PropertyInfo property;
            Expression propertyAccess;

            if (ordering.Contains('.'))
            {
                var childProperties = ordering.Split('.');
                property = type.GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);

                for (var i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i]);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(T).GetProperty(ordering);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }

            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var resultExp = Expression.Call(typeof(Queryable), ascending ? "OrderBy" : "OrderByDescending", new[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));

            return source.Provider.CreateQuery<T>(resultExp);
        }
    }
}