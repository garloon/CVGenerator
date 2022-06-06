using System.Linq;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    /// <summary>
    /// Расширеная модель для фильтрации <see cref="EmployeeProject"/>
    /// </summary>
    public class ExtendedEmployeeProjectFilter : EmployeeProjectFilter, IExtendedBaseFilterModel<EmployeeProject, long, GeneratorContext>
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
        /// Поиск подстроки имени сотрудника
        /// </summary>
        public string EmployeeNameSearching { get; set; }

        /// <summary>
        /// Поиск подстроки наименования проекта для клиента
        /// </summary>
        public string ShowProjectNameSearching { get; set; }

        /// <summary>
        /// Поиск подстроки наименования проекта
        /// </summary>
        public string ProjectNameSearching { get; set; }

        /// <summary>
        /// Поиск подстроки роли на проекте
        /// </summary>
        public string RoleNameSearching { get; set; }

        /// <summary>
        /// Поиск подстроки описания проекта
        /// </summary>
        public string DescriptionProjectSearching { get; set; }

        public override IQueryable<EmployeeProject> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(EmployeeNameSearching))
            {
                query = query.Where(pr =>
                    (pr.Employee.FirstName + " " + pr.Employee.MiddleName + " " + pr.Employee.LastName)
                    .Contains(EmployeeNameSearching));
            }

            if (!string.IsNullOrEmpty(ShowProjectNameSearching))
            {
                query = query.Where(pr => pr.ShowName.Contains(ShowProjectNameSearching));
            }

            if (!string.IsNullOrEmpty(ProjectNameSearching))
            {
                query = query.Where(pr => pr.Project.Name.Contains(ProjectNameSearching));
            }

            if (!string.IsNullOrEmpty(RoleNameSearching))
            {
                query = query.Where(pr => pr.ProjectRole.Name.Contains(RoleNameSearching));
            }

            if (!string.IsNullOrEmpty(DescriptionProjectSearching))
            {
                query = query.Where(pr => pr.DescriptionProject.Contains(DescriptionProjectSearching));
            }

            query = this.AddOrder(query);
            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);

            return query;
        }
    }
}