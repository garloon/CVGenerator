using System.Collections.Generic;
using System.Threading.Tasks;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CVGenerator.Core.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity, in TKey, TContext, TModel>
        where TContext : DbContext
        where TModel : IBaseFilterModel<TEntity, TKey, TContext>
        where TEntity : class, IEntityBase<TKey>, new()
    {
        Task<List<TEntity>> GetAsync(TModel model);

        Task<TEntity> GetFirstOrDefaultAsync(TModel model);

        Task<TEntity> GetLastOrDefaultAsync(TModel model);

        Task<int> GetCountAsync(TModel model); 

        Task<bool> IsExistAsync(TModel model);

        Task AddAsync(TEntity entity);

        Task AddAsync(IEnumerable<TEntity> entities);

        Task<EntityEntry<TEntity>> AddAndReturnEntityAsync(TEntity entity);

        Task ModifyAsync(TEntity entity);

        Task ModifyAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(IEnumerable<TEntity> entities);
        Task Save();
    }
}
