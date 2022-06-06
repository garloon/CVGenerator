using CVGenerator.Core.Repositories.FilterModels.Interfaces;
using CVGenerator.Core.Data.Entities;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    /// <summary>
    /// Расширеная модель для фильтрации <see cref="ProjectRole"/>
    /// </summary>
    public class ExtendedProjectRoleFilter : ProjectRoleFilter, IExtendedBaseFilterModel<ProjectRole, int, GeneratorContext>
    {
        /// <summary>
        /// Количество строк, которое нужно получить
        /// </summary>
        public int TakeCount { get; set; } = int.MaxValue;

        /// <summary>
        /// Количество строк, которое нужно пропустить
        /// </summary>
        public int SkipCount { get; set; }

        /// <summary>
        /// Поле для сортировки
        /// </summary>
        public string Ordering { get; set; } = "Id";

        /// <summary>
        /// Порядок сортировки по возрастанию? По умолчанию "true".
        /// </summary>
        public bool Ascending { get; set; } = true;

        /// <summary>
        /// Поиск подстроки наименования
        /// </summary>
        public string RoleNameSearching { get; set; }

        /// <summary>
        /// Поиск подстроки краткого наименования
        /// </summary>
        public string ShortRoleNameSearching { get; set; }

        public override IQueryable<ProjectRole> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(RoleNameSearching))
            {
                query = query.Where(pr => pr.Name.Contains(RoleNameSearching));
            }

            if (!string.IsNullOrEmpty(ShortRoleNameSearching))
            {
                query = query.Where(pr => pr.ShortName.Contains(ShortRoleNameSearching));
            }

            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);
            query = this.AddOrder(query);

            return query;
        }
    }
}