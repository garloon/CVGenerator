using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CVGenerator.Core.Data.Entities;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="Project"/>
    /// </summary>
    public class ProjectFilter : BaseFilterModel<Project, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public ProjectFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public ProjectFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public ProjectFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Наименование проекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Строка, которая используется в поиске
        /// </summary>
        public string NameSubString { get; set; }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Идентификаторы во внешней системе
        /// </summary>
        public IEnumerable<string> ExternalIds { get; set; }

        /// <summary>
        /// Указывает, нужно ли включать список сотрудников на проекте
        /// </summary>
        public bool IncludeEmployees { get; set; }

        /// <summary>
        /// Указывает, нужно ли включать список навыков на проекте
        /// </summary>
        public bool IncludeHardSkills { get; set; }

        public override IQueryable<Project> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(q => q.Name == Name);                
            }

            if (!string.IsNullOrEmpty(NameSubString))
            {
                query = query.Where(q => q.Name.Contains(NameSubString));
            }

            if (!string.IsNullOrEmpty(ExternalId))
            {
                query = query.Where(q => q.ExternalId == ExternalId);
            }

            if (ExternalIds?.Count() > 0)
            {
                query = query.Where(q => !string.IsNullOrEmpty(q.ExternalId) &&
                                         ExternalIds.Contains(q.ExternalId));
            }

            query = AddEmployees(query, IncludeEmployees);
            query = AddHardSkills(query, IncludeHardSkills);

            return query;
        }

        private static IQueryable<Project> AddEmployees(IQueryable<Project> query, bool includeEmployees)
        {
            if (includeEmployees)
            {
                query = query
                    .Include(p => p.Employees)
                        .ThenInclude(ep => ep.Employee)
                    .Include(p => p.Employees)
                        .ThenInclude(ep => ep.ProjectRole);
            }

            return query;
        }

        private static IQueryable<Project> AddHardSkills(IQueryable<Project> query, bool includeHardSkills)
        {
            if (includeHardSkills)
            {
                query = query
                    .Include(p => p.HardSkills)
                    .ThenInclude(ps => ps.HardSkill);
            }
            return query;
        }
    }
}