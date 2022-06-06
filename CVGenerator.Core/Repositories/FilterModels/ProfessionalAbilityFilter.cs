using System.Linq;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="ProfessionalAbility"/>
    /// </summary>
    public class ProfessionalAbilityFilter : BaseFilterModel<ProfessionalAbility, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public ProfessionalAbilityFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public ProfessionalAbilityFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public ProfessionalAbilityFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Наименование профессионального навыка
        /// </summary>
        public string Name { get; set; }

        public long? SectionId { get; set; }

        public override IQueryable<ProfessionalAbility> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(q => q.Name == Name);
            }

            if (SectionId.HasValue)
            {
                query = query.Where(q => q.SectionId == SectionId.Value);
            }

            return query;
        }
    }
}