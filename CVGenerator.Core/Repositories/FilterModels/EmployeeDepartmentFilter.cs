using System.Linq;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="EmployeeDepartment"/>
    /// </summary>
    public class EmployeeDepartmentFilter : BaseFilterModel<EmployeeDepartment, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EmployeeDepartmentFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EmployeeDepartmentFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EmployeeDepartmentFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор направления
        /// </summary>
        public long? DepartmentId { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// Нужно ли возвращать направление <see cref="EmployeeDepartment.Department"/>
        /// </summary>
        public bool IncludeDepartment { get; set; }

        /// <summary>
        /// Нужно ли возвращать сотрудника <see cref="EmployeeDepartment.Employee"/>
        /// </summary>
        public bool IncludeEmployee { get; set; }

        public override IQueryable<EmployeeDepartment> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (DepartmentId.HasValue)
            {
                query = query.Where(q => q.DepartmentId == DepartmentId.Value);
            }

            if (EmployeeId.HasValue)
            {
                query = query.Where(q => q.EmployeeId == EmployeeId.Value);
            }

            query = AddDepartment(query, IncludeDepartment);
            query = AddEmployee(query, IncludeEmployee);

            return query;
        }

        protected static IQueryable<EmployeeDepartment> AddDepartment(IQueryable<EmployeeDepartment> query, bool includeDepartment)
        {
            if (includeDepartment)
            {
                query = query.Include(l => l.Department);
            }

            return query;
        }

        protected static IQueryable<EmployeeDepartment> AddEmployee(IQueryable<EmployeeDepartment> query, bool includeEmployee)
        {
            if (includeEmployee)
            {
                query = query.Include(l => l.Employee);
            }

            return query;
        }
    }
}