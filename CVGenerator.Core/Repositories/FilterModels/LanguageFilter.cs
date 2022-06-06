using System.Linq;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="Language"/>
    /// </summary>
    public class LanguageFilter : BaseFilterModel<Language, int, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public LanguageFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public LanguageFilter(int id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public LanguageFilter(int id, bool asNoTracking)
            : base(id, asNoTracking) { }

        public override IQueryable<Language> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            return query;
        }
    }
}