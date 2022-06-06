using System;
using System.Linq;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="TemporaryReference"/>
    /// </summary>
    public class TemporaryReferenceFilter : BaseFilterModel<TemporaryReference, Guid, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public TemporaryReferenceFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public TemporaryReferenceFilter(Guid id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public TemporaryReferenceFilter(Guid id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Нужно ли возвращать CV <see cref="TemporaryReference.Cv"/>
        /// </summary>
        public bool IncludeCv { get; set; }

        /// <summary>
        /// Идентификатор CV
        /// </summary>
        public string CvId { get; set; }

        public override IQueryable<TemporaryReference> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (Guid.TryParse(CvId, out var result))
            {
                query = query.Where(q => q.CvId == result);
            }

            query = AddCv(query, IncludeCv);

            return query;
        }

        protected static IQueryable<TemporaryReference> AddCv(IQueryable<TemporaryReference> query, bool includeCv)
        {
            if (includeCv)
            {
                query = query.Include(l => l.Cv).ThenInclude(cv => cv.Employee);
            }

            return query;
        }
    }
}