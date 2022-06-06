using Microsoft.EntityFrameworkCore;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Repositories.FilterModels.Interfaces
{
    public interface IExtendedBaseFilterModel<TEntity, TKey, TContext> : IBaseFilterModel<TEntity, TKey, TContext>
        where TContext : DbContext
        where TEntity : IEntityBase<TKey>, new()
    {
        /// <summary>
        /// Количество строк, которое нужно получить
        /// </summary>
        int TakeCount { get; }

        /// <summary>
        /// Количество строк, которое нужно пропустить
        /// </summary>
        int SkipCount { get; }

        /// <summary>
        /// Поле для сортировки
        /// </summary>
        string Ordering { get; }

        /// <summary>
        /// Порядок сортировки по возрастанию? По умолчанию "true".
        /// </summary>
        bool Ascending { get; }
    }
}
