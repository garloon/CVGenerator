using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CVGenerator.Core.Data.Entities;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels.Interfaces
{
    public interface IBaseFilterModel<TEntity, TKey, TContext>
        where TContext : DbContext
        where TEntity : IEntityBase<TKey>, new()
    {
        /// <summary>
        /// Список идентификаторов сущностей
        /// </summary>
        IEnumerable<TKey> Ids { get; }

        IQueryable<TEntity> GetQueryable(TContext context);
    }
}
