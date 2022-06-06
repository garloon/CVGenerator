using Microsoft.EntityFrameworkCore.ChangeTracking;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using CVGenerator.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CVGenerator.Core.Data.Entities;
using System.Linq;
using System;

namespace CVGenerator.Core.Repositories
{
    public abstract class BaseRepository<TEntity, TKey, TContext, TModel> : IBaseRepository<TEntity, TKey, TContext, TModel>
        where TContext : DbContext
        where TModel : IBaseFilterModel<TEntity, TKey, TContext>
        where TEntity : EntityBase<TKey>, new()
    {
        protected BaseRepository(TContext context)
        {
            Context = context ?? throw new NullReferenceException();
            EntityOriginal = context.Set<TEntity>();
        }

        protected DbSet<TEntity> EntityOriginal { get; }

        protected TContext Context { get; }

        protected virtual IQueryable<TEntity> Entity => EntityOriginal;

        public virtual async Task<List<TEntity>> GetAsync(TModel model)
        {
            var query = model.GetQueryable(Context);
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<TEntity> GetFirstOrDefaultAsync(TModel model)
        {
            var query = model.GetQueryable(Context);
            return await query.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public virtual async Task<TEntity> GetLastOrDefaultAsync(TModel model)
        {
            var query = model.GetQueryable(Context);
            return await query.OrderByDescending(x => x.Id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public virtual async Task<int> GetCountAsync(TModel model)
        {
            var query = model.GetQueryable(Context);
            return await query.CountAsync().ConfigureAwait(false);
        }

        public virtual async Task<bool> IsExistAsync(TModel model)
        {
            var query = model.GetQueryable(Context);
            return await query.AnyAsync().ConfigureAwait(false);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await EntityOriginal.AddAsync(entity).ConfigureAwait(false);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task<EntityEntry<TEntity>> AddAndReturnEntityAsync(TEntity entity)
        {
            var responseEntity = await EntityOriginal.AddAsync(entity).ConfigureAwait(false);
            await Context.SaveChangesAsync().ConfigureAwait(false);

            return responseEntity;
        }

        public virtual async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await EntityOriginal.AddRangeAsync(entities).ConfigureAwait(false);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task ModifyAsync(TEntity entity)
        {
            EntityOriginal.Update(entity);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task ModifyAsync(IEnumerable<TEntity> entities)
        {
            EntityOriginal.UpdateRange(entities);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            EntityOriginal.Remove(entity);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            EntityOriginal.RemoveRange(entities);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task Save()
        {
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}