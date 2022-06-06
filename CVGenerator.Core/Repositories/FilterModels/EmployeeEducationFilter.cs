using System.Linq;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="EmployeeEducation"/>
    /// </summary>
    public class EmployeeEducationFilter : BaseFilterModel<EmployeeEducation, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EmployeeEducationFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EmployeeEducationFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EmployeeEducationFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор образования
        /// </summary>
        public long? EducationId { get; set; }

        /// <summary>
        /// Нужно ли возвращать <see cref="EmployeeEducation.Education"/>
        /// </summary>
        public bool IncludeEducation { get; set; }

        /// <summary>
        /// Нужно ли возвращать <see cref="EmployeeEducation.Employee"/>
        /// </summary>
        public bool IncludeEmployee { get; set; }

        public override IQueryable<EmployeeEducation> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (EmployeeId.HasValue)
            {
                query = query.Where(q => q.EmployeeId == EmployeeId.Value);
            }

            if (EducationId.HasValue)
            {
                query = query.Where(q => q.EducationId == EducationId.Value);
            }

            query = AddEducation(query, IncludeEducation);
            query = AddEmployee(query, IncludeEmployee);

            return query;
        }

        protected static IQueryable<EmployeeEducation> AddEducation(IQueryable<EmployeeEducation> query, bool includeEducation)
        {
            if (includeEducation)
            {
                query = query.Include(l => l.Education);
            }

            return query;
        }

        protected static IQueryable<EmployeeEducation> AddEmployee(IQueryable<EmployeeEducation> query, bool includeEmployee)
        {
            if (includeEmployee)
            {
                query = query.Include(l => l.Employee);
            }

            return query;
        }
    }
}