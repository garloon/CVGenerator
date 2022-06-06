using System;

namespace CVGenerator.Core.Data.Entities
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        protected EntityBase()
        {
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Дата деактивации
        /// </summary>
        public DateTime? Deleted { get; set; }

        /// <summary>
        /// Весрия записи
        /// </summary>
        public uint Version { get; set; }
    }
}
