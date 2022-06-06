using Microsoft.EntityFrameworkCore;
using CVGenerator.Core.Data.Entities;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="EmployeeCertificate"/>
    /// </summary>
    public class EmployeeCertificateFilter : BaseFilterModel<EmployeeCertificate, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public EmployeeCertificateFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public EmployeeCertificateFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public EmployeeCertificateFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор сертификата
        /// </summary>
        public long? CertificateId { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// Нужно ли возвращать сертификат <see cref="EmployeeCertificate.Certificate"/>
        /// </summary>
        public bool IncludeCertificate { get; set; }

        /// <summary>
        /// Нужно ли возвращать сотрудника <see cref="EmployeeDepartment.Employee"/>
        /// </summary>
        public bool IncludeEmployee { get; set; }

        public override IQueryable<EmployeeCertificate> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (CertificateId.HasValue)
            {
                query = query.Where(q => q.CertificateId == CertificateId.Value);
            }

            if (EmployeeId.HasValue)
            {
                query = query.Where(q => q.EmployeeId == EmployeeId.Value);
            }

            query = AddCertificate(query, IncludeCertificate);
            query = AddEmployee(query, IncludeEmployee);

            return query;
        }

        protected static IQueryable<EmployeeCertificate> AddCertificate(IQueryable<EmployeeCertificate> query, bool includeCertificate)
        {
            if (includeCertificate)
            {
                query = query.Include(l => l.Certificate);
            }

            return query;
        }

        protected static IQueryable<EmployeeCertificate> AddEmployee(IQueryable<EmployeeCertificate> query, bool includeEmployee)
        {
            if (includeEmployee)
            {
                query = query.Include(l => l.Employee);
            }

            return query;
        }
    }
}