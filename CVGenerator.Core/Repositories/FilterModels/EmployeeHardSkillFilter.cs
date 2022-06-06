using System.Linq;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="EmployeeHardSkill"/>
    /// </summary>
    public class EmployeeHardSkillFilter : BaseFilterModel<EmployeeHardSkill, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EmployeeHardSkillFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EmployeeHardSkillFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EmployeeHardSkillFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор навыка
        /// </summary>
        public long? HardSkillId { get; set; }

        /// <summary>
        /// Нужно ли возвращать модель с данными <see cref="Employee"/>
        /// </summary>
        public bool IncludeEmployee { get; set; }

        /// <summary>
        /// Нужно ли возвращать модель с данными по <see cref="HardSkill"/>
        /// </summary>
        public bool IncludeHardSkill { get; set; }

        public override IQueryable<EmployeeHardSkill> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (EmployeeId.HasValue)
            {
                query = query.Where(q => q.EmployeeId == EmployeeId.Value);
            }

            if (HardSkillId.HasValue)
            {
                query = query.Where(q => q.HardSkillId == HardSkillId.Value);
            }

            query = AddEmployee(query, IncludeEmployee);
            query = AddHardSkill(query, IncludeHardSkill);

            return query;
        }

        protected static IQueryable<EmployeeHardSkill> AddEmployee(IQueryable<EmployeeHardSkill> query, bool includeEmployee)
        {
            if (includeEmployee)
            {
                query = query.Include(l => l.Employee);
            }

            return query;
        }

        protected static IQueryable<EmployeeHardSkill> AddHardSkill(IQueryable<EmployeeHardSkill> query, bool includeHardSkill)
        {
            if (includeHardSkill)
            {
                query = query.Include(l => l.HardSkill);
            }

            return query;
        }
    }
}