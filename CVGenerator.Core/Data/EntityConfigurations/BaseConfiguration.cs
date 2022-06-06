using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public abstract class BaseConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase<TKey>
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.UseXminAsConcurrencyToken();
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Created).HasColumnType("timestamp").IsRequired();
            builder.Property(c => c.Updated).HasColumnType("timestamp");
            builder.Property(c => c.Deleted).HasColumnType("timestamp");
            builder.Property(x => x.Version).HasDefaultValue(0).IsRowVersion().IsConcurrencyToken();

            ConfigureCustom(builder);
        }

        protected abstract void ConfigureCustom(EntityTypeBuilder<TEntity> builder);
    }
}
