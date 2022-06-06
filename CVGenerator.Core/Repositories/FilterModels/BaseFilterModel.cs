using CVGenerator.Core.Repositories.FilterModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CVGenerator.Core.Data.Entities;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels
{
    public abstract class BaseFilterModel<TEntity, TKey, TContext> : IBaseFilterModel<TEntity, TKey, TContext>
        where TContext : DbContext
        where TEntity : EntityBase<TKey>, new()
    {
        protected BaseFilterModel() { }

        protected BaseFilterModel(TKey id)
        {
            Ids = new[] { id };
        }

        protected BaseFilterModel(TKey id, bool asNoTracking)
        {
            Ids = new[] { id };
            AsNoTracking = asNoTracking;
        }

        /// <summary>
        /// Не отслеживать объекты?
        /// </summary>
        public bool AsNoTracking { get; set; }

        /// <summary>
        /// Список идентификаторов сущностей
        /// </summary>
        public IEnumerable<TKey> Ids { get; set; }

        /// <summary>
        /// Если True, исключаются объекты, у которых поле Deleted != null
        /// </summary>
        public bool ExcludeDeleted { get; set; } = true;

        public virtual IQueryable<TEntity> GetQueryable(TContext context)
        {
            var query = (IQueryable<TEntity>)context.Set<TEntity>();

            if (Ids?.Count() > 0)
            {
                if (Ids.Count() == 1)
                {
                    var id = Ids.FirstOrDefault();
                    query = query.Where(m => Equals(m.Id, id));
                }
                else
                {
                    query = query.Where(m => Ids.Contains(m.Id));
                }
            }

            if (ExcludeDeleted)
            {
                query = query.Where(q => q.Deleted == null);
            }

            if (AsNoTracking)
            {
                query.AsNoTracking();
            }

            return query;
        }
    }
}