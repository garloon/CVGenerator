using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CVGenerator.Core.Data.Entities;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="Employee"/>
    /// </summary>
    public class EmployeeFilter : BaseFilterModel<Employee, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EmployeeFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EmployeeFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EmployeeFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Логин сотрудника
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public long? ExternalId { get; set; }

        /// <summary>
        /// Идентификатор отделения
        /// </summary>
        public long? DepartmentId { get; set; }

        /// <summary>
        /// Идентификатор локации сотрудника
        /// </summary>
        public long? LocationId { get; set; }

        /// <summary>
        /// Идентификаторы во внешней системе
        /// </summary>
        public IEnumerable<long?> ExternalIds { get; set; }

        /// <summary>
        /// Строка, которая должна содержаться в имени сотрудника
        /// </summary>
        public string NameSubString { get; set; }

        /// <summary>
        /// Статус сотрудника
        /// </summary>
        public EmployeeStatus? Status { get; set; }

        /// <summary>
        /// Указывает, нужно ли включать список <see cref="Department"/>
        /// </summary>
        public bool IncludeDepartments { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="HardSkill"/>
        /// </summary>
        public bool IncludeHardSkills { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="Project"/>
        /// </summary>
        public bool IncludeProjects { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="Cv"/>
        /// </summary>
        public bool IncludeCv { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="ProfessionalAbility"/>
        /// </summary>
        public bool IncludeProfessionalAbilities { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="Education"/>
        /// </summary>
        public bool IncludeEducations { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="Language"/>
        /// </summary>
        public bool IncludeLanguages { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="Certificate"/>
        /// </summary>
        public bool IncludeCertificates { get; set; }

        public override IQueryable<Employee> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (Login != null)
            {
                query = query.Where(q => q.Login == Login);
            }

            if (ExternalId.HasValue)
            {
                query = query.Where(q => q.ExternalId == ExternalId);
            }

            if (ExternalIds?.Count() > 0)
            {
                query = query.Where(q => q.ExternalId.HasValue && ExternalIds.Contains(q.ExternalId.Value));
            }

            if (DepartmentId.HasValue)
            {
                query = query.Where(q => q.Departments
                    .Where(d => d.DepartmentId == DepartmentId)
                    .Select(res => res.EmployeeId).Contains(q.Id));
            }

            if (LocationId.HasValue)
            {
                query = query.Where(q => q.Departments
                    .Where(d => d.DepartmentId == LocationId)
                    .Select(res => res.EmployeeId).Contains(q.Id));
            }

            if (!string.IsNullOrEmpty(NameSubString))
            {
                query = query.Where(q => (q.LastName + " " + q.FirstName + " " + (q.MiddleName ?? string.Empty)).Contains(NameSubString));
            }

            if (Status.HasValue)
            {
                query = query.Where(q => q.Status == Status);
            }

            query = AddDepartments(query);
            query = AddHardSkills(query);
            query = AddProjects(query);
            query = AddProfessionalAbilities(query);
            query = AddCertificates(query);
            query = AddEducations(query);
            query = AddLanguages(query);
            query = AddCv(query);

            return query;
        }

        private IQueryable<Employee> AddCv(IQueryable<Employee> query)
        {
            if(IncludeCv)
            {
                query = query.Include(employee => employee.Cvs);
            }

            return query;
        }

        private IQueryable<Employee> AddDepartments(IQueryable<Employee> query)
        {
            if (IncludeDepartments)
            {
                query = query.Include(employee => employee.Departments)
                    .ThenInclude(d => d.Department);
            }

            return query;
        }

        private IQueryable<Employee> AddHardSkills(IQueryable<Employee> query)
        {
            if (IncludeHardSkills)
            {
                query = query
                    .Include(employee => employee.HardSkills)
                    .ThenInclude(s => s.HardSkill);
            }

            return query;
        }

        private IQueryable<Employee> AddProjects(IQueryable<Employee> query)
        {
            if (!IncludeProjects)
            {
                return query;
            }

            query = query
                .Include(employee => employee.Projects)
                .ThenInclude(s => s.Project);

            query = query
                .Include(employee => employee.Projects)
                .ThenInclude(s => s.ProjectRole);

            return query;
        }

        private IQueryable<Employee> AddProfessionalAbilities(IQueryable<Employee> query)
        {
            if (IncludeProfessionalAbilities)
            {
                query = query
                    .Include(employee => employee.ProfessionalAbilities)
                    .ThenInclude(s => s.ProfessionalAbility);
            }

            return query;
        }

        private IQueryable<Employee> AddCertificates(IQueryable<Employee> query)
        {
            if (IncludeCertificates)
            {
                query = query
                    .Include(employee => employee.Certificates)
                    .ThenInclude(s => s.Certificate);
            }

            return query;
        }

        private IQueryable<Employee> AddEducations(IQueryable<Employee> query)
        {
            if (IncludeEducations)
            {
                query = query
                    .Include(employee => employee.Educations)
                    .ThenInclude(s => s.Education);
            }

            return query;
        }

        private IQueryable<Employee> AddLanguages(IQueryable<Employee> query)
        {
            if (IncludeLanguages)
            {
                query = query
                    .Include(employee => employee.Languages)
                    .ThenInclude(s => s.Language);
            }

            return query;
        }
    }
}