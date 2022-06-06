using System.Linq;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="ProjectRole"/>
    /// </summary>
    public class ProjectRoleFilter : BaseFilterModel<ProjectRole, int, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public ProjectRoleFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public ProjectRoleFilter(int id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public ProjectRoleFilter(int id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Наименование роли на проекте
        /// </summary>
        public string NameRole { get; set; }

        /// <summary>
        /// Короткое название (абривиатура)
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Наименование роли от пользователя?
        /// </summary>
        public bool IsPersonal { get; set; }

        public override IQueryable<ProjectRole> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (IsPersonal)
            {
                query = query.Where(q => q.IsPersonal == IsPersonal);
            }

            if (NameRole != null)
            {
                query = query.Where(q => q.Name == NameRole);
            }

            if (ShortName != null)
            {
                query = query.Where(q => q.ShortName == ShortName);
            }

            return query;
        }
    }
}