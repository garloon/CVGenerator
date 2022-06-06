using System.Linq;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="EmployeeProject"/>
    /// </summary>
    public class EmployeeProjectFilter : BaseFilterModel<EmployeeProject, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EmployeeProjectFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EmployeeProjectFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EmployeeProjectFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public long? ProjectId { get; set; }

        /// <summary>
        /// Нужно ли возвращать модель с данными сотрудника <see cref="Employee"/>
        /// </summary>
        public bool IncludeEmployee { get; set; }

        /// <summary>
        /// Нужно ли возвращать модель с данными по проекту <see cref="Project"/>
        /// </summary>
        public bool IncludeProject { get; set; }

        /// <summary>
        /// Нужно ли возвращать модель с данными по роли на проекте <see cref="ProjectRole"/>
        /// </summary>
        public bool IncludeProjectRole { get; set; }

        public override IQueryable<EmployeeProject> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (EmployeeId.HasValue)
            {
                query = query.Where(q => q.EmployeeId == EmployeeId.Value);
            }

            if (ProjectId.HasValue)
            {
                query = query.Where(q => q.ProjectId == ProjectId.Value);
            }

            query = AddEmployee(query, IncludeEmployee);
            query = AddProject(query, IncludeProject);
            query = AddRole(query, IncludeProjectRole);

            return query;
        }

        protected static IQueryable<EmployeeProject> AddEmployee(IQueryable<EmployeeProject> query, bool includeEmployee)
        {
            if (includeEmployee)
            {
                query = query.Include(l => l.Employee);
            }

            return query;
        }

        protected static IQueryable<EmployeeProject> AddProject(IQueryable<EmployeeProject> query, bool includeProject)
        {
            if (includeProject)
            {
                query = query.Include(l => l.Project);
            }

            return query;
        }

        protected static IQueryable<EmployeeProject> AddRole(IQueryable<EmployeeProject> query, bool includeRole)
        {
            if (includeRole)
            {
                query = query.Include(l => l.ProjectRole);
            }

            return query;
        }
    }
}