using System.Linq;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="EmployeeProfessionalAbility"/>
    /// </summary>
    public class EmployeeProfessionalAbilityFilter : BaseFilterModel<EmployeeProfessionalAbility, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EmployeeProfessionalAbilityFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EmployeeProfessionalAbilityFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EmployeeProfessionalAbilityFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public long? ProfessionalAbilityId { get; set; }

        /// <summary>
        /// Нужно ли возвращать модель с данными сотрудника <see cref="Employee"/>
        /// </summary>
        public bool IncludeEmployee { get; set; }

        /// <summary>
        /// Нужно ли возвращать модель с данными по проекту <see cref="Project"/>
        /// </summary>
        public bool IncludeProfessionalAbility { get; set; }

        /// <summary>
        /// Нужно ли возвращать модель с данными по роли на проекте <see cref="ProjectRole"/>
        /// </summary>
        public bool IncludeProjectRole { get; set; }

        public override IQueryable<EmployeeProfessionalAbility> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (EmployeeId.HasValue)
            {
                query = query.Where(q => q.EmployeeId == EmployeeId.Value);
            }

            if (ProfessionalAbilityId.HasValue)
            {
                query = query.Where(q => q.ProfessionalAbilityId == ProfessionalAbilityId.Value);
            }

            query = AddEmployee(query, IncludeEmployee);
            query = AddProfessionalAbility(query, IncludeProfessionalAbility);

            return query;
        }

        protected static IQueryable<EmployeeProfessionalAbility> AddEmployee(IQueryable<EmployeeProfessionalAbility> query, bool includeEmployee)
        {
            if (includeEmployee)
            {
                query = query.Include(l => l.Employee);
            }

            return query;
        }

        protected static IQueryable<EmployeeProfessionalAbility> AddProfessionalAbility(IQueryable<EmployeeProfessionalAbility> query, bool includeProject)
        {
            if (includeProject)
            {
                query = query.Include(l => l.ProfessionalAbility);
            }

            return query;
        }
    }
}