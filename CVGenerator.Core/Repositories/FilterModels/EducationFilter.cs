using System.Linq;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="Education"/>
    /// </summary>
    public class EducationFilter : BaseFilterModel<Education, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EducationFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EducationFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EducationFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Название учебного заведения
        /// </summary>
        public string UniversityName { get; set; }

        /// <summary>
        /// Тип специальности
        /// </summary>
        public TypeSpecialty TypeSpecialty { get; set; }

        public override IQueryable<Education> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (TypeSpecialty != byte.MinValue)
            {
                query = query.Where(q => q.TypeSpecialty == TypeSpecialty);
            }

            if (!string.IsNullOrEmpty(UniversityName))
            {
                query = query.Where(q => q.UniversityName == UniversityName);
            }

            return query;
        }
    }
}