using System.Linq;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="EmployeeProfessionalAbility"/>
    /// </summary>
    public class EmployeeAbilityFilter : BaseFilterModel<EmployeeProfessionalAbility, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EmployeeAbilityFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EmployeeAbilityFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EmployeeAbilityFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// Нужно ли возвращать направление <see cref="EmployeeProfessionalAbility.ProfessionalAbility"/>
        /// </summary>
        public bool IncludeAbility { get; set; }

        public override IQueryable<EmployeeProfessionalAbility> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (EmployeeId.HasValue)
            {
                query = query.Where(q => q.EmployeeId == EmployeeId.Value);
            }

            query = AddAbility(query, IncludeAbility);

            return query;
        }

        protected static IQueryable<EmployeeProfessionalAbility> AddAbility(IQueryable<EmployeeProfessionalAbility> query, bool includeAbility)
        {
            if (includeAbility)
            {
                query = query.Include(l => l.ProfessionalAbility);
            }

            return query;
        }
    }
}