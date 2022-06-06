using System.Linq;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="ProjectHardSkill"/>
    /// </summary>
    public class ProjectHardSkillFilter : BaseFilterModel<ProjectHardSkill, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public ProjectHardSkillFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public ProjectHardSkillFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public ProjectHardSkillFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        public override IQueryable<ProjectHardSkill> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            return query;
        }
    }
}