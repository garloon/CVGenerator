using System.Collections.Generic;
using CVGenerator.Core.Data.Entities;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="Certificate"/>
    /// </summary>
    public class CertificateFilter : BaseFilterModel<Certificate, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public CertificateFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public CertificateFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public CertificateFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public long? ExternalId { get; set; }

        /// <summary> 
        /// Идентификаторы внешней системы
        /// </summary>
        public IEnumerable<long> ExternalIds { get; set; }

        public override IQueryable<Certificate> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (ExternalId.HasValue)
            {
                query = query.Where(q => q.ExternalId == ExternalId);
            }

            if (ExternalIds?.Count() > 0)
            {
                query = query.Where(q => q.ExternalId.HasValue && ExternalIds.Contains(q.ExternalId.Value));
            }

            return query;
        }
    }
}