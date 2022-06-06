using System.Linq;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="EmployeeLanguage"/>
    /// </summary>
    public class EmployeeLanguageFilter : BaseFilterModel<EmployeeLanguage, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EmployeeLanguageFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EmployeeLanguageFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EmployeeLanguageFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор языка
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Нужно ли возвращать <see cref="EmployeeLanguage.Language"/>
        /// </summary>
        public bool IncludeLanguage { get; set; }

        public override IQueryable<EmployeeLanguage> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (EmployeeId.HasValue)
            {
                query = query.Where(q => q.EmployeeId == EmployeeId.Value);
            }

            if (LanguageId.HasValue)
            {
                query = query.Where(q => q.LanguageId == LanguageId.Value);
            }

            query = AddLanguage(query, IncludeLanguage);

            return query;
        }

        protected static IQueryable<EmployeeLanguage> AddLanguage(IQueryable<EmployeeLanguage> query, bool includeLanguage)
        {
            if (includeLanguage)
            {
                query = query.Include(l => l.Language);
            }

            return query;
        }

    }
}