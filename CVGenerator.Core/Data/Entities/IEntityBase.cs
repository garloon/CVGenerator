using System;

namespace CVGenerator.Core.Data.Entities
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        DateTime Updated { get; set; }

        /// <summary>
        /// Дата деактивации
        /// </summary>
        DateTime? Deleted { get; set; }

        /// <summary>
        /// Весрия записи
        /// </summary>
        uint Version { get; set; }
    }
}
